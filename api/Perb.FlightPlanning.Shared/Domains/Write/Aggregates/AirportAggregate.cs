using Perb.FlightPlanning.Shared.Domains.Write.Commands.Airport;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.Framework.Domains.Write.Aggregates;

namespace Perb.FlightPlanning.Shared.Domains.Write.Aggregates
{
    public class AirportAggregate : BaseAggregate<AirportState>
    {
        public AirportAggregate(AirportState state) : base(state)
        {
            
        }

        public AirportAggregate(AddAirport cmd)
        {
            State = new AirportState
            {
                Id = cmd.AggregateId,
                Name = cmd.Name,
                Iata = cmd.Iata,
                Icao = cmd.Icao
            };
        }

        public void ChangeName(string name)
        {
            State.Name = name;
        }

        public void ChangeIata(string iata)
        {
            State.Iata = iata;
        }

        public void ChangeIcao(string icao)
        {
            State.Icao = icao;
        }
    }
}