using System;
using Perb.FlightPlanning.Shared.Domains.Write.Entities;
using Perb.Framework;
using Perb.Framework.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Domains.Write.States
{
    public class AircraftContractState : BaseState
    {
        public Guid AircraftTypeId { get; set; }
        public string Name { get; set; }
        public TimeSpan MaintenanceTime { get; set; }
        public TimeSpan DailyTime { get; set; }
        public bool HasCrewRegulation { get; set; }
        public PlanningState Planning { get; set; }
    }
}