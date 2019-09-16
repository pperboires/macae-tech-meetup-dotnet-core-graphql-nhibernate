using System;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.Framework.Domains.Read;

namespace Perb.FlightPlanning.Shared.Domains.Read.Models
{
    public class PlannedFlightModel : BaseModel
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public int? Seats { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public MarineUnitModel MarineUnit { get; set; }
        public AircraftContractModel AircraftContract { get; set; }

        public SolutionModel Solution { get; set; }
    }
}