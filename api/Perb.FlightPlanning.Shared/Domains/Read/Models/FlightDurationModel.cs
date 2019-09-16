using Perb.Framework.Domains.Read;

namespace Perb.FlightPlanning.Shared.Domains.Read.Models
{
    public class FlightDurationModel : BaseModel
    {
        public AirportModel Airport { get; set; }
        public AircraftTypeModel AircraftType { get; set; }
        public int RoundTripDurationInMinutes { get; set; }
        public MarineUnitModel MarineUnit { get; set; }
    }
}