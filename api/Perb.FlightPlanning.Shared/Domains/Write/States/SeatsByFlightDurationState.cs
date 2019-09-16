using Perb.Framework.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Domains.Write.States
{
    public class SeatsByFlightDurationState : BaseState
    {
        public int Seats { get; set; }
        public int MinInMinutes { get; set; }
        public int MaxInMinutes { get; set; }
        public AircraftTypeState AircraftType { get; set; }
    }
}