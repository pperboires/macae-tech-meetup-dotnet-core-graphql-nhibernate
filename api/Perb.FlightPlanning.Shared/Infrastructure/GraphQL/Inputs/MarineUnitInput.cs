using System;
using System.Collections.Generic;
using GraphQL.Conventions;
using GraphQL.Conventions.Adapters.Types;
using GraphQL.Types;
using Perb.FlightPlanning.Shared.Domains.Write.Entities;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Inputs
{
    [InputType]
    [Description("Marine unit")]
    public class MarineUnitInput
    {
        [Description("ID")]
        public Guid AggregateId { get; set; }
        
        [Description("Name")]
        public NonNull<string> Name { get; set; }

        [Description("Demand")] 
        public int Demand { get; set; }

        [Description("Flight durations")]
        public NonNull<IList<FlightDuration>> FlightDurations { get; set; }
        
        [Description("Flight preferences")]
        public NonNull<IList<FlightPreference>> FlightPreferences { get; set; }
    }
}