using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.Solution;

namespace Perb.FlightPlanning.Shared.Domains.Write.ValueObject.Solver.Response
{
    

    /// <summary>
    /// FlightPlannerResult
    /// </summary>
    public class FlightPlannerResultResponse
    {
       
        [JsonProperty(PropertyName = "clientConnectionId")]
        public string ClientConnectionId { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "plannedFlights")]
        public IList<PlannedFlightResponse> PlannedFlights { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "score")]
        public ScoreResponse Score { get; set; }

        [JsonProperty(PropertyName = "planningId")]
        public Guid PlanningId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public SaveSolution ToSaveSolutionCommand()
        {
            var cmd = new SaveSolution
            {
                ClientConnectionId = ClientConnectionId,
                AggregateId = Guid.NewGuid(),
                Score = new SolutionScore
                {
                    Soft = Score.Soft,
                    Medium = Score.Medium,
                    Hard = Score.Hard
                },
                    PlanningId = PlanningId,
                Name = Name,
                Date = DateTime.UtcNow,
                PlannedFlights = PlannedFlights.Select(x => new PlannedFlight
                {
                    Id = Guid.NewGuid(),
                    DayOfWeek = x.DayOfWeek,
                    Seats = x.Seats,
                    Start = TimeSpan.FromMinutes(x.Start),
                    End = TimeSpan.FromMinutes(x.End),
                    MarineUnitId = x.MarineUnit.Id,
                    AircraftContractId = x.AircraftContract.Id
                }).ToList()
            };

            return cmd;
        }
    }
}
