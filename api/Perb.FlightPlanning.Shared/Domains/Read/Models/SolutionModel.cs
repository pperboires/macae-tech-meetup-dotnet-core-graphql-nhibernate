using System;
using System.Collections.Generic;
using Perb.Framework.Domains.Read;

namespace Perb.FlightPlanning.Shared.Domains.Read.Models
{
    public class SolutionModel : BaseModel
    {
        public Guid PlanningId { get; set; }
        
        public DateTime Date { get; set; }
        public string Name { get; set; }
        
        public IList<PlannedFlightModel> PlannedFlights { get; set; } = new List<PlannedFlightModel>();

        public SolutionScoreModel Score { get; set; }
    }
}