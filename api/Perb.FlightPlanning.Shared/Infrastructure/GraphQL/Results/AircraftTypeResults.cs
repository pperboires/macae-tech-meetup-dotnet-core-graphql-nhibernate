using System.Collections.Generic;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Results
{
    [Description("Result of operation add aircraft type")]
    public class AddAircraftTypeResult : IRelayMutationOutputObject
    {
        public string ClientMutationId { get; set; }
        
        [Description("Aircraft type added.")]
        public AircraftTypeModel AircraftType { get; set; }
    }
    
    [Description("Result of operation update aircraft type")]
    public class UpdateAircraftTypeResult : IRelayMutationOutputObject
    {
        public string ClientMutationId { get; set; }
        
        [Description("Aircraft type updated.")]
        public AircraftTypeModel AircraftType { get; set; }
    }
    
    [Description("Result of operation remove aircraft types")]
    public class RemoveAircraftTypesResult : IRelayMutationOutputObject
    {
        public string ClientMutationId { get; set; }
        
        [Description("Total removed")]
        public int TotalRemoved { get; set; }

        [Description("Current aircraft types.")]
        public IList<AircraftTypeModel> AircraftTypes { get; set; } = new List<AircraftTypeModel>();
    }
}