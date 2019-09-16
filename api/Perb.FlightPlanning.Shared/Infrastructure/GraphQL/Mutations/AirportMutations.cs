using System.Linq;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using Perb.FlightPlanning.Shared.Domains.Read.Repositories;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.Airport;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Params;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Results;
using Perb.Framework.Domains.Write;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Mutations
{
    [ImplementViewer(OperationType.Mutation)]
    public sealed class AirportMutations
    {
        private readonly ICommandRouter _commandRouter;
        private readonly IAirportReadRepository _airportReadRepository;

        public AirportMutations(ICommandRouter commandRouter, IAirportReadRepository airportReadRepository)
        {
            _commandRouter = commandRouter;
            _airportReadRepository = airportReadRepository;
        }
       
        [RelayMutation]
        public AddAirportResult AddAirport(NonNull<AddAirportParams> @params)
        {
            _commandRouter.Send(new AddAirport
            {
                AggregateId = @params.Value.Airport.Value.AggregateId,
                Name = @params.Value.Airport.Value.Name,
                Iata = @params.Value.Airport.Value.Iata,
                Icao = @params.Value.Airport.Value.Icao
            });

            var queryModel = _airportReadRepository.GetById(@params.Value.Airport.Value.AggregateId);

            return new AddAirportResult
            {
                Airport = queryModel,
                ClientMutationId = @params.Value.ClientMutationId
            };
        }

        [RelayMutation]
        public UpdateAirportResult UpdateAirport(NonNull<UpdateAirportParams> @params)
        {
            _commandRouter.Send(new UpdateAirport
            {
                AggregateId = @params.Value.Airport.Value.AggregateId,
                Name = @params.Value.Airport.Value.Name,
                Iata = @params.Value.Airport.Value.Iata,
                Icao = @params.Value.Airport.Value.Icao
            });

            var queryModel = _airportReadRepository.GetById(@params.Value.Airport.Value.AggregateId);

            return new UpdateAirportResult
            {
                Airport = queryModel,
                ClientMutationId = @params.Value.ClientMutationId
            };
        }

        [RelayMutation]
        public RemoveAirportsResult RemoveAirports(NonNull<RemoveAirportsParams> @params)
        {
            _commandRouter.Send(new RemoveAirports
            {
                AggregateIds = @params.Value.Ids.Value
            });

            var totalRemoved = @params.Value.Ids.Value.Count;

            return new RemoveAirportsResult
            {
                TotalRemoved = totalRemoved,
                ClientMutationId = @params.Value.ClientMutationId,
                Airports = _airportReadRepository.GetQuery().ToList()
            };
        }
    }
}