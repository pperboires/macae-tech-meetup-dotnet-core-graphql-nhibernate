using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Perb.FlightPlanning.Shared.Domains.Write.Aggregates;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.AircraftType;
using Perb.FlightPlanning.Shared.Domains.Write.Repositories;

namespace Perb.FlightPlanning.Shared.Domains.Write.CommandHandlers
{
    public class AircraftTypeCommandHandler :
        IRequestHandler<AddAircraftType>,
        IRequestHandler<UpdateAircraftType>,
        IRequestHandler<RemoveAircraftTypes>
    {
        private readonly IAircraftTypeWriteRepository _aircraftTypeWriteRepository;

        public AircraftTypeCommandHandler(IAircraftTypeWriteRepository aircraftTypeWriteRepository)
        {
            _aircraftTypeWriteRepository = aircraftTypeWriteRepository;
        }
        
        Task<Unit> IRequestHandler<AddAircraftType, Unit>.Handle(AddAircraftType request, CancellationToken cancellationToken)
        {
            var aggregate = new AircraftTypeAggregate(request.AggregateId, request.Code, request.Name);
            aggregate.SetSeatsByDuration(request.SeatsByDuration);
            _aircraftTypeWriteRepository.Save(aggregate);
            
            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(UpdateAircraftType request, CancellationToken cancellationToken)
        {
            var aggregate = _aircraftTypeWriteRepository.GetById(request.AggregateId);
            aggregate.ChangeCode(request.Code);
            aggregate.ChangeName(request.Name);
            aggregate.SetSeatsByDuration(request.SeatsByDuration);
            _aircraftTypeWriteRepository.Save(aggregate);
            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(RemoveAircraftTypes request, CancellationToken cancellationToken)
        {
            _aircraftTypeWriteRepository.DeleteByIds(request.AggregateIds);
            return Task.FromResult(new Unit());
        }
    }
}