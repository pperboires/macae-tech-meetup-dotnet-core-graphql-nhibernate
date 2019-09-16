using FluentNHibernate.Mapping;
using GraphQL;
using Perb.FlightPlanning.Shared.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Write
{
    public class AircraftTypeStateMap : ClassMap<AircraftTypeState>
    {
        public AircraftTypeStateMap()
        {
            Schema("Core");
            
            Table("AircraftType");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Name);
            Map(x => x.Code);
            
            HasMany(x => x.SeatsByFlightDuration)
                .KeyColumn("AircraftTypeId")
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}