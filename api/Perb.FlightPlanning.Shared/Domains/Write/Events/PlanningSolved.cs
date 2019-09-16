using System;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Domains.Write.Events;

namespace Perb.FlightPlanning.Shared.Domains.Write.Events
{
    public class PlanningSolved : IEvent
    {
        public Guid PlanningId { get; set; }
        public Guid SolutionId { get; set; }
    }

    public class SolutionScoreChanged : IEvent
    {
        public Guid PlanningId { get; set; }
        public SolutionScore NewScore { get; set; }
    }
}