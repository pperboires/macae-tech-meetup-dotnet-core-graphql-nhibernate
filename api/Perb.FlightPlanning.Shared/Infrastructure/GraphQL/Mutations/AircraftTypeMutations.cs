using System.Linq;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using Perb.FlightPlanning.Shared.Domains.Read.Repositories;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.AircraftType;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Params;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Results;
using Perb.Framework.Domains.Write;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Mutations
{
    [ImplementViewer(OperationType.Mutation)]
    public sealed class AircraftTypeMutations
    {
        private readonly IAircraftTypeReadRepository _aircraftTypeReadRepository;
        private readonly ICommandRouter _commandRouter;

        public AircraftTypeMutations(ICommandRouter commandRouter,
            IAircraftTypeReadRepository aircraftTypeReadRepository
        )
        {
            _aircraftTypeReadRepository = aircraftTypeReadRepository;
            _commandRouter = commandRouter;
        }
       
        [RelayMutation]
        public AddAircraftTypeResult AddAircraftType(NonNull<AddAircraftTypeParams> @params)
        {
            _commandRouter.Send(new AddAircraftType
            {
                AggregateId = @params.Value.AircraftType.Value.AggregateId,
                Name = @params.Value.AircraftType.Value.Name,
                Code = @params.Value.AircraftType.Value.Code,
                SeatsByDuration = @params.Value.AircraftType.Value.SeatsByDuration.Value
            });

            var aircraftType = _aircraftTypeReadRepository.GetById(@params.Value.AircraftType.Value.AggregateId);

            return new AddAircraftTypeResult
            {
                AircraftType = aircraftType,
                ClientMutationId = @params.Value.ClientMutationId
            };
        }

        [RelayMutation]
        public UpdateAircraftTypeResult UpdateAircraftType(NonNull<UpdateAircraftTypeParams> @params)
        {
            _commandRouter.Send(new UpdateAircraftType
            {
                AggregateId = @params.Value.AircraftType.Value.AggregateId,
                Name = @params.Value.AircraftType.Value.Name,
                Code = @params.Value.AircraftType.Value.Code,
                SeatsByDuration = @params.Value.AircraftType.Value.SeatsByDuration.Value
            });

            var aircraftType = _aircraftTypeReadRepository.GetById(@params.Value.AircraftType.Value.AggregateId);

            return new UpdateAircraftTypeResult
            {
                AircraftType = aircraftType,
                ClientMutationId = @params.Value.ClientMutationId
            };
        }

        [RelayMutation]
        public RemoveAircraftTypesResult RemoveAircraftTypes(NonNull<RemoveAircraftTypesParams> @params)
        {
            _commandRouter.Send(new RemoveAircraftTypes
            {
                AggregateIds = @params.Value.Ids.Value
            });

            var totalRemoved = @params.Value.Ids.Value.Count;

            return new RemoveAircraftTypesResult
            {
                TotalRemoved = totalRemoved,
                ClientMutationId = @params.Value.ClientMutationId,
                AircraftTypes = _aircraftTypeReadRepository.GetQuery().ToList()
            };
        }
    }
}