using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Read
{
    public class AirportModelMap : ClassMap<AirportModel>
    {
        public AirportModelMap()
        {
            ReadOnly();
            
            Schema("Core");
            
            Table("Airport");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Name);
            Map(x => x.Iata);
            Map(x => x.Icao);
        }
    }
}