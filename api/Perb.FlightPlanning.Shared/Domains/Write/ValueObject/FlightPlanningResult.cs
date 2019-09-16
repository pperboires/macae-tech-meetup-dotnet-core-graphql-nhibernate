using System;
using System.Collections.Generic;

namespace Perb.FlightPlanning.Shared.Domains.Write.ValueObject
{
    public class FlightPlanningResult
    {
        public string ClientConnectionId { get; set; }
        public IList<PlannedFlight> PlannedFlights { get; set; } = new List<PlannedFlight>();
    }

    public class PlannedFlight : Period
    {
        public MarineUnit MarineUnit { get; set; }
        public string AircraftContract { get; set; }
        public int Seats { get; set; }
    }

    public class Score
    {
        public long Hard { get; set; }
        public long Medium { get; set; }
        public long Soft { get; set; }
    }

    public class Period
    {
        public int Start { get; set; }
        public int End { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }

    public class MarineUnit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}