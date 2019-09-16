using System.Collections.Generic;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Results
{
    [Description("Result of operation add marine unit")]
    public class AddMarineUnitResult : IRelayMutationOutputObject
    {
        public string ClientMutationId { get; set; }
        
        [Description("Marine unit added.")]
        public MarineUnitModel MarineUnit { get; set; }
    }

    [Description("Result of operation update marine unit")]
    public class UpdateMarineUnitResult : IRelayMutationOutputObject
    {
        public string ClientMutationId { get; set; }
        
        [Description("Marine unit updated.")]
        public MarineUnitModel MarineUnit { get; set; }
    }
    
    [Description("Result of operation remove marine units")]
    public class RemoveMarineUnitsResult : IRelayMutationOutputObject
    {
        public string ClientMutationId { get; set; }
        
        [Description("Total removed")]
        public int TotalRemoved { get; set; }

        [Description("Current marine units.")]
        public IList<MarineUnitModel> MarineUnits { get; set; } = new List<MarineUnitModel>();
    }
}