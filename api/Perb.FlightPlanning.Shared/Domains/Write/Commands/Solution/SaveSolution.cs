using System;
using System.Collections.Generic;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Domains.Write.Commands;

namespace Perb.FlightPlanning.Shared.Domains.Write.Commands.Solution
{
    public class SaveSolution : AggregateCommand
    {
        public string ClientConnectionId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Guid PlanningId { get; set; }
        public SolutionScore Score { get; set; }
        public IList<PlannedFlight> PlannedFlights { get; set; } = new List<PlannedFlight>();
    }
    
    public class PlannedFlight
    {
        public Guid Id { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public int? Seats { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public Guid MarineUnitId { get; set; }
        public Guid AircraftContractId { get; set; }
    }
}