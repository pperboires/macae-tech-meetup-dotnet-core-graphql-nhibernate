using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Write
{
    public class SeatsByFlightDurationStateMap : ClassMap<SeatsByFlightDurationState>
    {
        public SeatsByFlightDurationStateMap()
        {
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