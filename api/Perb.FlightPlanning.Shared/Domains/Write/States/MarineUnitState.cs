using System.Collections.Generic;
using Perb.Framework.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Domains.Write.States
{
    public class MarineUnitState : BaseState
    {
        public string Name { get; set; }
        public int Demand { get; set; }
        public IList<FlightDurationState> FlightDurations { get; set; } = new List<FlightDurationState>();
        public IList<FlightPreferenceState> FlightPreferences { get; set; } = new List<FlightPreferenceState>();
    }
}