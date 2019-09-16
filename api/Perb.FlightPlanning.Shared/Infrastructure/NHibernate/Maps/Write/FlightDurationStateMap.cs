using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Write
{
    public class FlightDurationStateMap : ClassMap<FlightDurationState>
    {
        public FlightDurationStateMap()
        {
            Schema("Core");
            
            Table("FlightDuration");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.AirportId);
            Map(x => x.AircraftTypeId);
            Map(x => x.RoundTripDurationInMinutes);

            References(x => x.MarineUnit, "MarineUnitId");
        }
    }
}