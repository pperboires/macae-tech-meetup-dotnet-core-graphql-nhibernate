using System.Linq;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using Perb.FlightPlanning.Shared.Domains.Read.Repositories;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.MarineUnit;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Params;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Results;
using Perb.Framework.Domains.Write;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Mutations
{
    [ImplementViewer(OperationType.Mutation)]
    public sealed class MarineUnitMutations
    {
        private readonly IMarineUnitReadRepository _marineUnitReadRepository;
        private readonly ICommandRouter _commandRouter;

        public MarineUnitMutations(ICommandRouter commandRouter,
            IMarineUnitReadRepository marineUnitReadRepository)
        {
            _marineUnitReadRepository = marineUnitReadRepository;
            _commandRouter = commandRouter;
        }
        
        [RelayMutation]
        public AddMarineUnitResult AddMarineUnit(NonNull<AddMarineUnitParams> @params)
        {
            _commandRouter.Send(new AddMarineUnit
            {
                AggregateId = @params.Value.MarineUnit.Value.AggregateId,
                Name = @params.Value.MarineUnit.Value.Name,
                Demand = @params.Value.MarineUnit.Value.Demand,
                FlightDurations = @params.Value.MarineUnit.Value.FlightDurations.Value,
                FlightPreferences = @params.Value.MarineUnit.Value.FlightPreferences.Value
            });

            var marineUnit = _marineUnitReadRepository.GetById(@params.Value.MarineUnit.Value.AggregateId);

            return new AddMarineUnitResult
            {
                MarineUnit = marineUnit,
                ClientMutationId = @params.Value.ClientMutationId
            };
        }

        public UpdateMarineUnitResult UpdateMarineUnit(NonNull<UpdateMarineUnitParams> @params)
        {
            _commandRouter.Send(new UpdateMarineUnit
            {
                AggregateId = @params.Value.MarineUnit.Value.AggregateId,
                Name = @params.Value.MarineUnit.Value.Name,
                Demand = @params.Value.MarineUnit.Value.Demand,
                FlightPreferences = @params.Value.MarineUnit.Value.FlightPreferences.Value,
                FlightDurations = @params.Value.MarineUnit.Value.FlightDurations.Value
            });

            var marineUnit = _marineUnitReadRepository.GetById(@params.Value.MarineUnit.Value.AggregateId);

            return new UpdateMarineUnitResult
            {
                MarineUnit = marineUnit,
                ClientMutationId = @params.Value.ClientMutationId
            };
        }
        
        [RelayMutation]
        public RemoveMarineUnitsResult RemoveMarineUnits(NonNull<RemoveMarineUnitsParams> @params)
        {
            _commandRouter.Send(new RemoveMarineUnits
            {
                AggregateIds = @params.Value.Ids.Value
            });

            var totalRemoved = @params.Value.Ids.Value.Count;

            return new RemoveMarineUnitsResult
            {
                TotalRemoved = totalRemoved,
                ClientMutationId = @params.Value.ClientMutationId,
                MarineUnits = _marineUnitReadRepository.GetQuery().ToList()
            };
        }
    }
}