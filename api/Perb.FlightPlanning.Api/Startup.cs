using System;
using GraphQL.Server.Ui.Playground;
using LightInject;
using LightInject.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Perb.FlightPlanning.Api.Logging;
using Perb.FlightPlanning.Shared.Infrastructure.IOC;
using Perb.Framework.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;

namespace Perb.FlightPlanning.Api
{
    public class Startup
    {
        private static readonly ILog Logger = LogProvider.For<Startup>();
        
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            
            builder.AddEnvironmentVariables();
            
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            
            services.AddMvc().AddControllersAsServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            
            
            var containerOptions = new ContainerOptions {EnablePropertyInjection = false};
            var container = new ServiceContainer(containerOptions)
            {
                ScopeManagerProvider = new PerLogicalCallContextScopeManagerProvider()
            };

            container.RegisterFrom<LightInjectModule>();
            
            container.RegisterInstance<IAppSettingsRetriever>(new AppSettingsRetriever(Configuration));
            container.Register<IHttpContextAccessor, HttpContextAccessor>(new PerContainerLifetime());
          
            
            return container.CreateServiceProvider(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                Logger.Info("Using Developer Exception Page.");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                Logger.Info("Using HSTS.");
                app.UseHsts();
            }
            
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseMvc();
            
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


           
                
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground",
                GraphQLEndPoint = $"/api/graph"
            });
            
            Logger.Info("App initialized.");
        }
        
    }
}