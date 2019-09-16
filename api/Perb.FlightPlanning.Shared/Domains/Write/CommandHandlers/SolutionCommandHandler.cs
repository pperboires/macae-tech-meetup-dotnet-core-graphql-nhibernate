using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Perb.FlightPlanning.Shared.Domains.Write.Aggregates;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.Planning;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.Solution;
using Perb.FlightPlanning.Shared.Domains.Write.Events;
using Perb.FlightPlanning.Shared.Domains.Write.Repositories;
using Perb.FlightPlanning.Shared.Domains.Write.Services;

namespace Perb.FlightPlanning.Shared.Domains.Write.CommandHandlers
{
    public class SolutionCommandHandler :
        IRequestHandler<SaveSolution>,
        IRequestHandler<ChangeSolutionName>
    {
        private readonly ISolutionWriteRepository _solutionWriteRepository;
        private readonly IClientNotifier _clientNotifier;

        public SolutionCommandHandler(ISolutionWriteRepository solutionWriteRepository, IClientNotifier clientNotifier)
        {
            _solutionWriteRepository = solutionWriteRepository;
            _clientNotifier = clientNotifier;
        }
        
        public Task<Unit> Handle(SaveSolution request, CancellationToken cancellationToken)
        {
            var aggregate = _solutionWriteRepository.GetById(request.AggregateId);

            if (aggregate == null)
            {
                aggregate = new SolutionAggregate(request);
            }
            
            _solutionWriteRepository.Save(aggregate);

            _clientNotifier.Broadcast("PlanningSolved", new PlanningSolved 
                { 
                    PlanningId = request.PlanningId, 
                    SolutionId = request.AggregateId
                });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(ChangeSolutionName request, CancellationToken cancellationToken)
        {
            var aggregate = _solutionWriteRepository.GetById(request.AggregateId);

            aggregate.ChangeName(request.Name);
            
            _solutionWriteRepository.Save(aggregate);
            
            return Task.FromResult(new Unit());
        }
    }
}