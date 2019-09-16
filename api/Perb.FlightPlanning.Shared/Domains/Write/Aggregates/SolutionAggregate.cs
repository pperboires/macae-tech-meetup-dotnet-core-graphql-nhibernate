using System.Linq;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.Solution;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Domains.Write.Aggregates;

namespace Perb.FlightPlanning.Shared.Domains.Write.Aggregates
{
    public class SolutionAggregate : BaseAggregate<SolutionState>
    {
        public SolutionAggregate(SolutionState state) : base(state)
        {
            
        }

        public SolutionAggregate(SaveSolution cmd)
        {
            State = new SolutionState
            {
                Id = cmd.AggregateId,
                Score = new SolutionScore
                {
                    Soft = cmd.Score.Soft,
                    Medium = cmd.Score.Medium,
                    Hard = cmd.Score.Hard
                },
                Date = cmd.Date,
                Name = cmd.Name,
                PlanningId = cmd.PlanningId
            };

            State.PlannedFlights = cmd.PlannedFlights.Select(x => new PlannedFlightState()
            {
                Solution = State,
                Id = x.Id,
                DayOfWeek = x.DayOfWeek,
                Seats = x.Seats,
                MarineUnitId = x.MarineUnitId,
                AircraftContractId = x.AircraftContractId,
                Start = x.Start,
                End = x.End
            }).ToList();
        }

        public void ChangeName(string newName)
        {
            State.Name = newName;
        }
    }
}