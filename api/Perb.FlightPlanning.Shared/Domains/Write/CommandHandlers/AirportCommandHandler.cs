using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Perb.FlightPlanning.Shared.Domains.Write.Aggregates;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.Airport;
using Perb.FlightPlanning.Shared.Domains.Write.Repositories;

namespace Perb.FlightPlanning.Shared.Domains.Write.CommandHandlers
{
    public class AirportCommandHandler :
        IRequestHandler<AddAirport>,
        IRequestHandler<UpdateAirport>,
        IRequestHandler<RemoveAirports>
    {
        private readonly IAirportWriteRepository _airportWriteRepository;

        public AirportCommandHandler(IAirportWriteRepository airportWriteRepository)
        {
            _airportWriteRepository = airportWriteRepository;
        }
        
        public Task<Unit> Handle(AddAirport request, CancellationToken cancellationToken)
        {
            var aggregate = new AirportAggregate(request);
            _airportWriteRepository.Save(aggregate);
            
            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(UpdateAirport request, CancellationToken cancellationToken)
        {
            var aggregate = _airportWriteRepository.GetById(request.AggregateId);
            aggregate.ChangeIata(request.Iata);
            aggregate.ChangeIcao(request.Icao);
            aggregate.ChangeName(request.Name);
            _airportWriteRepository.Save(aggregate);

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(RemoveAirports request, CancellationToken cancellationToken)
        {
            _airportWriteRepository.DeleteByIds(request.AggregateIds);

            return Task.FromResult(new Unit());
        }
    }
}