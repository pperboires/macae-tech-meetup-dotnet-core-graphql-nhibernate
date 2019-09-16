using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Perb.Framework.Logging;

namespace Perb.Framework.Infrastructure.MediatR
{
    public class GenericRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        private static readonly ILog Logger = LogProvider.For<GenericRequestPreProcessor<TRequest>>();
    
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            Logger.InfoFormat("Starting execution of {Request}.", request.GetType());
            return Task.CompletedTask;
        }
    }
}