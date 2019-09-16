using System.Net.NetworkInformation;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using GraphQL;
using GraphQL.Conventions;
using GraphQL.DataLoader;
using GraphQL.Http;
using GraphQL.Types;
using LightInject;
using MediatR;
using MediatR.Pipeline;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Dialect;
using Perb.FlightPlanning.Shared.Domains.Read.Repositories;
using Perb.FlightPlanning.Shared.Domains.Read.Repositories.Impl;
using Perb.FlightPlanning.Shared.Domains.Write.Repositories;
using Perb.FlightPlanning.Shared.Domains.Write.Repositories.Impl;
using Perb.FlightPlanning.Shared.Domains.Write.Services;
using Perb.FlightPlanning.Shared.Domains.Write.Services.Impl;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Mutations;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Queries;
using Perb.FlightPlanning.Shared.Infrastructure.NHibernate;
using Perb.Framework.Domains.Write;
using Perb.Framework.Infrastructure;
using Perb.Framework.Infrastructure.MediatR;
using Perb.Framework.Infrastructure.NHibernate;

namespace Perb.FlightPlanning.Shared.Infrastructure.IOC
{
    public class LightInjectModule : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            // READ REPOSITORIES
            serviceRegistry.Register<IAircraftTypeReadRepository, AircraftTypeReadRepository>();
            serviceRegistry.Register<IMarineUnitReadRepository, MarineUnitReadRepository>();
            serviceRegistry.Register<IAirportReadRepository, AirportReadRepository>();
            serviceRegistry.Register<IPlanningReadRepository, PlanningReadRepository>();
            serviceRegistry.Register<ISolutionReadRepository, SolutionReadRepository>();
            
            // WRITE REPOSITORIES
            serviceRegistry.Register<IAircraftTypeWriteRepository, AircraftTypeWriteRepository>();
            serviceRegistry.Register<IMarineUnitWriteRepository, MarineUnitWriteRepository>();
            serviceRegistry.Register<IAirportWriteRepository, AirportWriteRepository>();
            serviceRegistry.Register<IPlanningWriteRepository, PlanningWriteRepository>();
            serviceRegistry.Register<ISolutionWriteRepository, SolutionWriteRepository>();
            
            // INFRA
            serviceRegistry.Register<IAppSettingsRetriever, AppSettingsRetriever>(new PerContainerLifetime());
            serviceRegistry.Register<ICommandRouter, CommandRouter>(new PerContainerLifetime());
            
            // MEDIATOR 
            ConfigureMediator(serviceRegistry);
            
            
            // GRAPHQL
            ConfigureGraphQL(serviceRegistry);
            

            // NHIBERNATE
            serviceRegistry.Register<ISessionFactory>(CreateSessionFactory, new PerContainerLifetime());
            serviceRegistry.Register<ISession>(factory => factory.GetInstance<ISessionFactory>().OpenSession(), new PerScopeLifetime());
            serviceRegistry.Register<IUnitOfWork, NHibernateUnitOfWork>(new PerScopeLifetime());
            
            // SERVICES
            serviceRegistry.Register<IClientNotifier, ClientNotifier>();
            serviceRegistry.Register<IExternalEventHandler, ExternalEventHandler>();
        }

        private void ConfigureGraphQL(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IDependencyResolver>(factory => new FuncDependencyResolver(factory.GetInstance), new PerContainerLifetime());
            serviceRegistry.Register<IDependencyInjector, GraphQLDependencyInjector>(new PerContainerLifetime());
            serviceRegistry.Register<IUserContext, UserContext>();
            serviceRegistry.Register<DataLoaderContext>();
            
            serviceRegistry.Register<AircraftTypeQueries>();
            serviceRegistry.Register<MarineUnitQueries>();
            serviceRegistry.Register<AirportQueries>();
            serviceRegistry.Register<PlanningQueries>();
            serviceRegistry.Register<SolutionQueries>();
            
            serviceRegistry.Register<AircraftTypeMutations>();
            serviceRegistry.Register<MarineUnitMutations>();
            serviceRegistry.Register<AirportMutations>();
            serviceRegistry.Register<PlanningMutations>();


            var graphqlEngine = GraphQLEngine.New();
            graphqlEngine.WithQuery<AircraftTypeQueries>();
            graphqlEngine.WithQuery<MarineUnitQueries>();
            graphqlEngine.WithQuery<AirportQueries>();
            graphqlEngine.WithQuery<PlanningQueries>();
            graphqlEngine.WithQuery<SolutionQueries>();
            
            graphqlEngine.WithMutation<AircraftTypeMutations>();
            graphqlEngine.WithMutation<MarineUnitMutations>();
            graphqlEngine.WithMutation<AirportMutations>();
            graphqlEngine.WithMutation<PlanningMutations>();
            
            serviceRegistry.RegisterInstance(graphqlEngine.BuildSchema());
        }

        private ISessionFactory CreateSessionFactory(IServiceFactory serviceFactory)
        {
            NHibernateConnectionProvider
                .SetAppSettingsService(serviceFactory.GetInstance<IAppSettingsRetriever>());
            
            var config = Fluently.Configure()
                    .Database(PostgreSQLConfiguration.PostgreSQL82
                    .ShowSql()
                    .FormatSql()
                    .Provider<NHibernateConnectionProvider>()
                    .Dialect<PostgreSQL82Dialect>()
                    .AdoNetBatchSize(100))
                    //.CurrentSessionContext("call") // TODO ajustar o currentsessioncontext ainda..
                    //https://github.com/nhibernate/nhibernate-core/issues/1632
                    .Mappings(x => x.FluentMappings
                    .AddFromAssemblyOf<LightInjectModule>()
                   
                    .Conventions.Setup(c =>
                    {
                        c.Add(DefaultLazy.Never());
                    }))
                    .ExposeConfiguration(c =>
                    {
                        //c.SetProperty(Environment.DefaultFlushMode, FlushMode.Always.ToString());
                        c.SetProperty(Environment.Hbm2ddlKeyWords, "keywords"); // http://fabiomaulo.blogspot.com/2009/06/auto-quote-tablecolumn-names.html

                        
                        //https://stackoverflow.com/questions/2134565/how-to-configure-fluent-nhibernate-to-output-queries-to-trace-or-debug-instead-o
                        c.SetInterceptor(new SqlLoggingInterceptor());
                    })
                    .BuildConfiguration();

            return config.BuildSessionFactory();
        }
        
        
        private void ConfigureMediator(IServiceRegistry serviceRegistry)
        {
            // https://github.com/jbogard/MediatR/blob/master/samples/MediatR.Examples.LightInject/Program.cs
            serviceRegistry.Register<IMediator, Mediator>();
           
            serviceRegistry.RegisterAssembly(GetType().Assembly, (serviceType, implementingType) =>
                serviceType.IsConstructedGenericType &&
                (
                    serviceType.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
                    serviceType.GetGenericTypeDefinition() == typeof(INotificationHandler<>)
                ));
                    
            serviceRegistry.RegisterOrdered(typeof(IPipelineBehavior<,>),
                new[]
                {
                    typeof(RequestPreProcessorBehavior<,>),
                    typeof(RequestPostProcessorBehavior<,>),
                    typeof(GenericPipelineBehavior<,>)
                }, type => new PerContainerLifetime());

            
            serviceRegistry.RegisterOrdered(typeof(IRequestPostProcessor<,>),
                new[]
                {
                    typeof(GenericRequestPostProcessor<,>),
                    typeof(ConstrainedRequestPostProcessor<,>)
                }, type => new PerContainerLifetime());
            
            serviceRegistry.Register(typeof(IRequestPreProcessor<>), typeof(GenericRequestPreProcessor<>));            


            
            
            serviceRegistry.Register<ServiceFactory>(fac => fac.GetInstance);
        }
    }
}