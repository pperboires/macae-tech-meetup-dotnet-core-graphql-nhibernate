using System;
using System.Collections.Generic;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Domains.Write.States
{
    public class SolutionState : BaseState
    {
        public Guid PlanningId { get; set; }
        
        public DateTime Date { get; set; }
        public string Name { get; set; }
        
        public IList<PlannedFlightState> PlannedFlights { get; set; } = new List<PlannedFlightState>();

        public SolutionScore Score { get; set; }
    }
}