using System;
using GraphQL.Conventions;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Write.Entities
{
    [InputType]
    [Description("Flight preference")]
    public class FlightPreference : IIdentifiable
    {
        [Description("ID")]
        public Guid Id { get; set; }
        
        [Description("Day of week")]
        public DayOfWeek DayOfWeek { get; set; }
        
        [Description("Start")]
        public TimeSpan Start { get; set; }
        
        [Description("End")]
        public TimeSpan End { get; set; }
    }
}