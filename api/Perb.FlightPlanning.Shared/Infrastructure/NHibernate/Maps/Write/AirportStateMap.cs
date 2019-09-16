using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Write
{
    public class AirportStateMap : ClassMap<AirportState>
    {
        public AirportStateMap()
        {
            Schema("Core");
            
            Table("Airport");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Iata);
            Map(x => x.Icao);
            Map(x => x.Name);
        }
    }
}