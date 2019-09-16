using System.Collections.Generic;
using Perb.Framework.Domains.Read;

namespace Perb.FlightPlanning.Shared.Domains.Read.Models
{
    public class MarineUnitModel : BaseModel
    {
        public string Name { get; set; }
        public int Demand { get; set; }
        public IEnumerable<FlightDurationModel> FlightDurations { get; set; } = new HashSet<FlightDurationModel>();
        public IEnumerable<FlightPreferenceModel> FlightPreferences { get; set; } = new HashSet<FlightPreferenceModel>();
    }
}