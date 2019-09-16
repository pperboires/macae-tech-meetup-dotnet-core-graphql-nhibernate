using System;
using Perb.Framework.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Domains.Write.States
{
    public class PlannedFlightState : BaseState
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public int? Seats { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public Guid MarineUnitId { get; set; }
        public Guid AircraftContractId { get; set; }

        public SolutionState Solution { get; set; }
    }
}