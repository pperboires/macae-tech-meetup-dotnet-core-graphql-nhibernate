using Perb.Framework.Domains.Write.Commands;

namespace Perb.FlightPlanning.Shared.Domains.Write.Commands.Airport
{
    public class AddAirport : AggregateCommand
    {   
        public string Iata { get; set; }
        public string Name { get; set; }
        public string Icao { get; set; }
    }
}