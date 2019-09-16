using System.Threading.Tasks;
using MediatR.Pipeline;
using Perb.Framework.Logging;

namespace Perb.Framework.Infrastructure.MediatR
{
    public class GenericRequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private static readonly ILog Logger = LogProvider.For<GenericRequestPostProcessor<TRequest, TResponse>>();
        
        public Task Process(TRequest request, TResponse response)
        {
            Logger.Info("- All Done");
            return Task.CompletedTask;
        }
    }
}