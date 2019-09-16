using System;
using System.Collections.Generic;
using GraphQL.Conventions;
using Perb.FlightPlanning.Shared.Domains.Write.Entities;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Inputs
{
    [InputType]
    [Description("Aircraft type")]
    public class AircraftTypeInput
    {
        [Description("ID")]
        public Guid AggregateId { get; set; }
        
        [Description("Code")]
        public NonNull<string> Code { get; set; }

        [Description("Name")]
        public NonNull<string> Name { get; set; }

        [Description("Seats by duration")]
        public NonNull<IList<SeatsByFlightDuration>> SeatsByDuration { get; set; }
        
    }
}