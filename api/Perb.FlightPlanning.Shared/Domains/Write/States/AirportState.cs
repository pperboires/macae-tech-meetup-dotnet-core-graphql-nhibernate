using Perb.Framework.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Domains.Write.States
{
    public class AirportState : BaseState
    {
        public string Name { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
    }
}