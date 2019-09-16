using Perb.Framework.Domains.Read;

namespace Perb.FlightPlanning.Shared.Domains.Read.Models
{
    public class SeatsByFlightDurationModel : BaseModel
    {
        public int Seats { get; set; }
        
        public int MinInMinutes { get; set; }
        
        public int MaxInMinutes { get; set; }
        
        public AircraftTypeModel AircraftType { get; set; }
    }
}