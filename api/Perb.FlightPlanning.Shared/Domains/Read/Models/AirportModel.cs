using Perb.Framework.Domains.Read;

namespace Perb.FlightPlanning.Shared.Domains.Read.Models
{
    public class AirportModel : BaseModel
    {
        public string Name { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
    }
}