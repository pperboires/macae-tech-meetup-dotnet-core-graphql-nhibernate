using System.Collections.Generic;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Results
{
    [Description("Result of operation add airport")]
    public class AddAirportResult : IRelayMutationOutputObject
    {
        public string ClientMutationId { get; set; }
        
        [Description("Airport added.")]
        public AirportModel Airport { get; set; }
    }
    
    [Description("Result of operation update airport")]
    public class UpdateAirportResult : IRelayMutationOutputObject
    {
        public string ClientMutationId { get; set; }
        
        [Description("Airport updated.")]
        public AirportModel Airport { get; set; }
    }
    
    [Description("Result of operation remove aircraft types")]
    public class RemoveAirportsResult : IRelayMutationOutputObject
    {
        public string ClientMutationId { get; set; }
        
        [Description("Total removed")]
        public int TotalRemoved { get; set; }

        [Description("Current airports.")]
        public IList<AirportModel> Airports { get; set; } = new List<AirportModel>();
    }
}