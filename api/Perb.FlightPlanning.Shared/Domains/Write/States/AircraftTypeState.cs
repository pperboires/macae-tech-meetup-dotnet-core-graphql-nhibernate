using System.Collections.Generic;
using Perb.Framework;
using Perb.Framework.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Domains.Write.States
{
    public class AircraftTypeState : BaseState
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public IList<SeatsByFlightDurationState> SeatsByFlightDuration { get; set; } = new List<SeatsByFlightDurationState>();
    }
}