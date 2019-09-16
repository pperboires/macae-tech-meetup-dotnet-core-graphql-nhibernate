using System;
using Perb.Framework.Domains.Read;

namespace Perb.FlightPlanning.Shared.Domains.Read.Models
{
    public class AircraftContractModel : BaseModel
    {
        public string Name { get; set; }
        public TimeSpan DailyTime { get; set; }
        public TimeSpan MaintenanceTime { get; set; }
        public bool HasCrewRegulation { get; set; }
        public AircraftTypeModel AircraftType { get; set; }
    }
}