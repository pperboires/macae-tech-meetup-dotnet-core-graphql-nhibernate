using System;
using System.Collections.Generic;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Results
{
    [Description("Result of operation save planning")]
    public class SavePlanningResult : IRelayMutationOutputObject
    {
        public string ClientMutationId { get; set; }
        
        [Description("Planning saved.")]
        public PlanningModel Planning { get; set; }
    }

    [Description("Result of operation remove plannings")]
    public class RemovePlanningsResult : IRelayMutationOutputObject
    {
        public string ClientMutationId { get; set; }
        
        [Description("Total removed")]
        public int TotalRemoved { get; set; }

        [Description("Current plannings.")]
        public IList<PlanningModel> Plannings { get; set; } = new List<PlanningModel>();
    }

    [Description("Result of operation request to solve planning")]
    public class RequestToSolvePlanningResult : IRelayMutationOutputObject
    {
        public string ClientMutationId { get; set; }
        
        [Description("Planning ID.")]
        public Guid PlanningId { get; set; }
    }
}