using System;
using Microsoft.Extensions.Configuration;
using Perb.Framework.Logging;

namespace Perb.Framework.Infrastructure
{
    public class AppSettingsRetriever : IAppSettingsRetriever
    {
        private static readonly ILog Logger = LogProvider.For<AppSettingsRetriever>();
        
        private readonly IConfiguration _configuration;

        public AppSettingsRetriever(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetValue(string key, bool secret = false)
        {
            // TODO na nuvem podemos colocar algo aqui para tentar obter a configuracao externa.
            
            return _configuration[key];
        }
    }
}