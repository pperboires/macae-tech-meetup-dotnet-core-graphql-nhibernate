using System;
using System.Collections.Generic;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Inputs;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Params
{
    public class AddMarineUnitParams : IRelayMutationInputObject
    {
        public string ClientMutationId { get; set; }
        public NonNull<MarineUnitInput> MarineUnit { get; set; }
    }
    
    public class UpdateMarineUnitParams : IRelayMutationInputObject
    {
        public string ClientMutationId { get; set; }
        public NonNull<MarineUnitInput> MarineUnit { get; set; }
    }

    public class RemoveMarineUnitsParams : IRelayMutationInputObject
    {
        public string ClientMutationId { get; set; }
        public NonNull<IList<Guid>> Ids { get; set; }
    }
}