using System;
using GraphQL.Conventions;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Inputs
{
    [InputType]
    [Description("Airport")]
    public class AirportInput
    {
        [Description("ID")]
        public Guid AggregateId { get; set; }
        
        [Description("Name")]
        public NonNull<string> Name { get; set; }
        
        [Description("IATA")]
        public string Iata { get; set; }

        [Description("ICAO")]
        public string Icao { get; set; }
    }
}