using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Read
{
    public class AircraftTypeModelMap : ClassMap<AircraftTypeModel>
    {
        public AircraftTypeModelMap()
        {
            ReadOnly();
            
            Schema("Core");
            
            Table("AircraftType");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Name);
            Map(x => x.Code);

            HasMany(x => x.SeatsByFlightDuration)
                .KeyColumn("AircraftTypeId")
                .Cascade.AllDeleteOrphan()
                .Not.LazyLoad()
                .Fetch.Join()
                .Inverse();
        }
    }
}