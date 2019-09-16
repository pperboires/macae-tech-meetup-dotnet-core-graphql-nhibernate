using System;
using System.Reflection;
using GraphQL.Conventions;


namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL
{
    public class GraphQLDependencyInjector : IDependencyInjector
    {
        private readonly IServiceProvider _serviceProvider;

        public GraphQLDependencyInjector(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object Resolve(TypeInfo typeInfo)
        {
            return _serviceProvider.GetService(typeInfo);
        }
    }
}