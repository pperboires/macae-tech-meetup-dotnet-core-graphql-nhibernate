using System.Collections.Generic;
using Perb.Framework.Domains.Read;

namespace Perb.FlightPlanning.Shared.Domains.Read.Models
{
    public class AircraftTypeModel : BaseModel
    {
        public string Code { get; set; }
        
        public string Name { get; set; }
        
        public IList<SeatsByFlightDurationModel> SeatsByFlightDuration { get; set; } = new List<SeatsByFlightDurationModel>();
    }
}