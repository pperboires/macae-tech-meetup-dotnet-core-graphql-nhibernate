using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Perb.FlightPlanning.Shared.Domains.Write.Aggregates;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.MarineUnit;
using Perb.FlightPlanning.Shared.Domains.Write.Repositories;

namespace Perb.FlightPlanning.Shared.Domains.Write.CommandHandlers
{
    public class MarineUnitCommandHandler :
        IRequestHandler<AddMarineUnit>,
        IRequestHandler<UpdateMarineUnit>,
        IRequestHandler<RemoveMarineUnits>
    {
        private readonly IMarineUnitWriteRepository _marineUnitWriteRepository;

        public MarineUnitCommandHandler(IMarineUnitWriteRepository marineUnitWriteRepository)
        {
            _marineUnitWriteRepository = marineUnitWriteRepository;
        }
        
        public Task<Unit> Handle(AddMarineUnit request, CancellationToken cancellationToken)
        {
            var aggregate = new MarineUnitAggregate(request);
            _marineUnitWriteRepository.Save(aggregate);
            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(UpdateMarineUnit request, CancellationToken cancellationToken)
        {
            var aggregate = _marineUnitWriteRepository.GetById(request.AggregateId);
            aggregate.ChangeName(request.Name);
            aggregate.ChangeDemand(request.Demand);
            aggregate.SetFlightDurations(request.FlightDurations);
            aggregate.SetFlightPreferences(request.FlightPreferences);
            _marineUnitWriteRepository.Save(aggregate);
            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(RemoveMarineUnits request, CancellationToken cancellationToken)
        {
            _marineUnitWriteRepository.DeleteByIds(request.AggregateIds);
            return Task.FromResult(new Unit());
        }
    }
}