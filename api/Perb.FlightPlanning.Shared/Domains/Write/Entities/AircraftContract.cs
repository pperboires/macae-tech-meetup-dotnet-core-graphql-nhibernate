using System;
using GraphQL.Conventions;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Write.Entities
{
    [InputType]
    [Description("Aircraft contract")]
    public class AircraftContract : IIdentifiable
    {
        [Description("ID")]
        public Guid Id { get; set; }

        [Description("Name")]
        public string Name { get; set; }
        
        [Description("Aicraft type ID")]
        public Guid AircraftTypeId { get; set; }
        
        [Description("Maintenance time")]
        public TimeSpan MaintenanceTime { get; set; }
        
        [Description("Daily time")]
        public TimeSpan DailyTime { get; set; }
        
        [Description("Has crew regulation")]
        public bool HasCrewRegulation { get; set; }
    }
}