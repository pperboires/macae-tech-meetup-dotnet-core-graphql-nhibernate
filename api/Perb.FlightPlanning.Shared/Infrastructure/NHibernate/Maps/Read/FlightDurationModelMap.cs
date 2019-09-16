using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Read
{
    public class FlightDurationModelMap : ClassMap<FlightDurationModel>
    {
        public FlightDurationModelMap()
        {
            ReadOnly();
            
            Schema("Core");
            
            Table("FlightDuration");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.RoundTripDurationInMinutes);

            References(x => x.MarineUnit, "MarineUnitId");
            References(x => x.Airport, "AirportId");
            References(x => x.AircraftType, "AircraftTypeId");
        }
    }
}