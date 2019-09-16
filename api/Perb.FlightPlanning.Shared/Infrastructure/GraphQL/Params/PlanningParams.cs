using System;
using System.Collections.Generic;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Inputs;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Params
{
    public class SavePlanningParams : IRelayMutationInputObject
    {
        public string ClientMutationId { get; set; }
        public NonNull<PlanningInput> Planning { get; set; }
    }
   
    public class RemovePlanningsParams : IRelayMutationInputObject
    {
        public string ClientMutationId { get; set; }
        public NonNull<IList<Guid>> Ids { get; set; }
    }

    public class RequestToSolvePlanningParams : IRelayMutationInputObject
    {
        public string ClientMutationId { get; set; }
        public Guid PlanningId { get; set; }
        public string Name { get; set; }
    }
}