using System;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Domains.Write.States
{
    public class FlightDurationState : BaseState
    {
        public Guid AirportId { get; set; }
        public Guid AircraftTypeId { get; set; }
        public int RoundTripDurationInMinutes { get; set; }
        public MarineUnitState MarineUnit { get; set; }
    }
}