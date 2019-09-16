using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Read
{
    public class SeatsByFlightDurationModelMap : ClassMap<SeatsByFlightDurationModel>
    {
        public SeatsByFlightDurationModelMap()
        {
            ReadOnly();
            
            Schema("Core");
            
            Table("SeatsByFlightDuration");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Seats);
            Map(x => x.MinInMinutes);
            Map(x => x.MaxInMinutes);

            References(x => x.AircraftType, "AircraftTypeId");
        }
    }
}