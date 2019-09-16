using System;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.Solution;

namespace Perb.FlightPlanning.Shared.Domains.Write.ValueObject.Solver.Response
{
    public class SolutionScoreChangedResponse
    {
        public Guid PlanningId { get; set; }
        public SolutionScore  NewScore { get; set; }
    }
}