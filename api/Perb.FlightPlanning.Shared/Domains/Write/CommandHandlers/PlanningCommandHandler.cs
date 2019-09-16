using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Perb.FlightPlanning.Shared.Domains.Write.Aggregates;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.Planning;
using Perb.FlightPlanning.Shared.Domains.Write.Repositories;
using Perb.FlightPlanning.Shared.Domains.Write.Services;

namespace Perb.FlightPlanning.Shared.Domains.Write.CommandHandlers
{
    public class PlanningCommandHandler :
        IRequestHandler<SavePlanning>,
        IRequestHandler<RemovePlannings>
    {
        private readonly IPlanningWriteRepository _planningWriteRepository;

        public PlanningCommandHandler(IPlanningWriteRepository planningWriteRepository)
        {
            _planningWriteRepository = planningWriteRepository;
        }
        
        public Task<Unit> Handle(SavePlanning request, CancellationToken cancellationToken)
        {
            var aggregate = _planningWriteRepository.GetById(request.AggregateId);

            if (aggregate == null)
            {
                aggregate = new PlanningAggregate(request.AggregateId);
            }
            
            aggregate.ChangeComments(request.Comments);
            aggregate.ChangeName(request.Name);
            aggregate.ChangeAirportId(request.AirportId);
            aggregate.ChangeFirstFlight(request.FirstFlight);
            aggregate.ChangeLastFlight(request.LastFlight);
            aggregate.ChangeLastFlightType(request.LastFlightType);
            aggregate.ChangeMarineUnitIds(request.MarineUnitIds);
            aggregate.ChangeDaysOfWeek(request.DaysOfWeek);
            aggregate.ChangeAircraftContracts(request.AircraftContracts);
            
            _planningWriteRepository.Save(aggregate);
            
            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(RemovePlannings request, CancellationToken cancellationToken)
        {
            _planningWriteRepository.DeleteByIds(request.AggregateIds);
            return Task.FromResult(new Unit());
        }

    }
}