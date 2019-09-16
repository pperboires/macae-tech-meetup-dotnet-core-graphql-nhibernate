using System;
using GraphQL.Conventions;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Write.Entities
{
    [InputType]
    [Description("Flight duration")]
    public class FlightDuration : IIdentifiable
    {
        [Description("ID")]
        public Guid Id { get; set; }
        
        [Description("Airport ID")]
        public Guid AirportId { get; set; }
        
        [Description("Aircraft type ID")]
        public Guid AircraftTypeId { get; set; }
        
        [Description("Round trip duration (in minutes)")]
        public int RoundTripDurationInMinutes { get; set; }
    }
}