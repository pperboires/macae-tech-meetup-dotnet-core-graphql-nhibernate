using System;
using System.Collections.Generic;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Domains.Write.States
{
    public class PlanningState : BaseState
    {
        public string Name { get; set; }
        public Guid AirportId { get; set; }
        public TimeSpan FirstFlight { get; set; }
        public TimeSpan LastFlight { get; set; }
        public LastFlightType LastFlightType { get; set; }
        public IList<DayOfWeek> DaysOfWeek { get; set; } = new List<DayOfWeek>();
        public string Comments { get; set; }
        public IList<Guid> MarineUnitIds { get; set; } = new List<Guid>();
        public IList<AircraftContractState> AircraftContracts { get; set; } = new List<AircraftContractState>();
    }
}