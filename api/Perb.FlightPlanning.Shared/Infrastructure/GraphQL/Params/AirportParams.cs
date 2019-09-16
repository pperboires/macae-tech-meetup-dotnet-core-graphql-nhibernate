using System;
using System.Collections.Generic;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Inputs;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Params
{
    
    public class AddAirportParams : IRelayMutationInputObject
    {
        public string ClientMutationId { get; set; }
        public NonNull<AirportInput> Airport { get; set; }
    }

    public class UpdateAirportParams : IRelayMutationInputObject
    {
        public string ClientMutationId { get; set; }
        public NonNull<AirportInput> Airport { get; set; }
    }

    public class RemoveAirportsParams : IRelayMutationInputObject
    {
        public string ClientMutationId { get; set; }
        public NonNull<IList<Guid>> Ids { get; set; }
    }
    
}