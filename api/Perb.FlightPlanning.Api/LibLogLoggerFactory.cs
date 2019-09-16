using System;
using Microsoft.Extensions.Logging;
using Perb.FlightPlanning.Api.Logging;
using MicrosoftLogLevel = Microsoft.Extensions.Logging.LogLevel;
using LibLogLevel = Perb.FlightPlanning.Api.Logging.LogLevel;
namespace Perb.FlightPlanning.Api
{
    public class LibLogLogProvider : ILoggerProvider
    {
        public void Dispose()
        {
            
        }

        public ILogger CreateLogger(string categoryName)
        {
            var log = LogProvider.GetLogger(categoryName);
            var logger = new LibLogLogger(log);
            return logger;
        }
    }

    internal class LibLogLogger : ILogger
    {
        private readonly ILog _logger;

        public LibLogLogger(ILog logger)
        {
            _logger = logger;
        }
        
        public void Log<TState>(MicrosoftLogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var libLogLevel = MapLevel(logLevel);
            
            if (state == null)
            {
                _logger.Log(libLogLevel, null);
            }
            else
            {   
                _logger.Log(libLogLevel, () => formatter(state, exception), exception);
            }
        }

        public bool IsEnabled(MicrosoftLogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new LibLogFakeScope();
        }

        private LibLogLevel MapLevel(MicrosoftLogLevel microsoftLogLevel)
        {
            switch(microsoftLogLevel)
            {
                case MicrosoftLogLevel.Critical:
                    return LibLogLevel.Fatal;
                
                case MicrosoftLogLevel.Error:
                    return LibLogLevel.Error;
                
                case MicrosoftLogLevel.Warning:
                    return LibLogLevel.Warn;
                
                case MicrosoftLogLevel.Information:
                    return LibLogLevel.Info;
                
                case MicrosoftLogLevel.Debug:
                    return LibLogLevel.Debug;
                
                case MicrosoftLogLevel.Trace:
                    return LibLogLevel.Trace;
                
                default:
                    throw new ArgumentOutOfRangeException("microsoftLogLevel");
            }
        }
        
    }

    public class LibLogFakeScope : IDisposable
    {
        public void Dispose()
        {
            
        }
    }
}