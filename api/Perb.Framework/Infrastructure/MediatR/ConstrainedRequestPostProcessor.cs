using System.Threading.Tasks;
using MediatR.Pipeline;
using Perb.Framework.Domains.Write.Commands;
using Perb.Framework.Logging;

namespace Perb.Framework.Infrastructure.MediatR
{
    public class ConstrainedRequestPostProcessor<TRequest, TResponse>
        : IRequestPostProcessor<TRequest, TResponse>
        where TRequest : MultiAggregateCommand
    {
        private static readonly ILog Logger = LogProvider.For<ConstrainedRequestPostProcessor<TRequest, TResponse>>();


        public Task Process(TRequest request, TResponse response)
        {
            Logger.Info("- All Done with MultiAggregateCommand");
            return Task.CompletedTask;
        }
    }
}