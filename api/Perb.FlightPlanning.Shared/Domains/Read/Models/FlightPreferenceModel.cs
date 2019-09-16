using System;
using Perb.Framework.Domains.Read;

namespace Perb.FlightPlanning.Shared.Domains.Read.Models
{
    public class FlightPreferenceModel : BaseModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public MarineUnitModel MarineUnit { get; set; }
    }
}