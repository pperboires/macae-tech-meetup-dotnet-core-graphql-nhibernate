using System.Threading.Tasks;
using MediatR;
using Perb.Framework.Domains.Write.Commands;

namespace Perb.Framework.Domains.Write
{
    public class CommandRouter : ICommandRouter
    {
        private readonly IMediator _mediator;
  
        public CommandRouter(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public Task Send(Command cmd)
        {
            return _mediator.Send(cmd);
        }
    }
}