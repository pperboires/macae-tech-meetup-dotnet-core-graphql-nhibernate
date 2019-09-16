using System.Collections.Generic;
using NHibernate.Connection;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate
{
    public class NHibernateConnectionProvider : DriverConnectionProvider
    {
        private static IAppSettingsRetriever _appSettingsService;

        public static void SetAppSettingsService(IAppSettingsRetriever appSettingsService)
        {
            _appSettingsService = appSettingsService;
        }

        protected override string ConnectionString => _appSettingsService.GetValue("Sql:ConnectionString");

        public override void Configure(IDictionary<string, string> settings)
        {
            ConfigureDriver(settings);
        }
        
    }
}