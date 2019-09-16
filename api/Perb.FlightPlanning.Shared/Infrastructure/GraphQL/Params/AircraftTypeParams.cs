using System;
using System.Collections.Generic;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Inputs;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Params
{
    public class AddAircraftTypeParams : IRelayMutationInputObject
    {
        public string ClientMutationId { get; set; }
        public NonNull<AircraftTypeInput> AircraftType { get; set; }
    }
    
    public class UpdateAircraftTypeParams : IRelayMutationInputObject
    {
        public string ClientMutationId { get; set; }
        public NonNull<AircraftTypeInput> AircraftType { get; set; }
    }

    public class RemoveAircraftTypesParams : IRelayMutationInputObject
    {
        public string ClientMutationId { get; set; }
        public NonNull<IList<Guid>> Ids { get; set; }
    }
}