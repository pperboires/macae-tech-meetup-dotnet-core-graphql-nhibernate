using System;
using System.Collections.Generic;
using GraphQL.Conventions;
using Perb.FlightPlanning.Shared.Domains.Write.Entities;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Inputs
{
    [InputType]
    [Description("Planning")]
    public class PlanningInput
    {
        [Description("ID")]
        public Guid AggregateId { get; set; }
        
        [Description("Name")]
        public NonNull<string> Name { get; set; }
        
        [Description("Airport ID")]
        public Guid AirportId { get; set; }
        
        [Description("First flight")]
        public TimeSpan FirstFlight { get; set; }
        
        [Description("Last flight")]
        public TimeSpan LastFlight { get; set; }
        
        [Description("Last flight type")]
        public LastFlightType LastFlightType { get; set; }
        
        [Description("ID")]
        public IList<DayOfWeek> DaysOfWeek { get; set; } = new List<DayOfWeek>();
        
        [Description("Comments")]
        public string Comments { get; set; }
        
        [Description("Marine unit IDs")]
        public NonNull<IList<Guid>> MarineUnitIds { get; set; } 
        
        [Description("Aircraft contracts")]
        public NonNull<IList<AircraftContract>> AircraftContracts { get; set; } 
    }
}