using System;

namespace Perb.FlightPlanning.Shared.Domains.Write.ValueObject
{
    public class MarineUnitFlightPreference
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}