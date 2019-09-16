using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Read
{
    public class MarineUnitModelMap : ClassMap<MarineUnitModel>
    {
        public MarineUnitModelMap()
        {
            ReadOnly();
            
            Schema("Core");
            
            Table("MarineUnit");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Name);
            Map(x => x.Demand);
            
            HasMany(x => x.FlightPreferences)
                .KeyColumn("MarineUnitId")
                .Cascade.AllDeleteOrphan()
                .Not.LazyLoad()
                .AsSet()
                .Fetch.Join()
                .Inverse();
            
            HasMany(x => x.FlightDurations)
                .KeyColumn("MarineUnitId")
                .Cascade.AllDeleteOrphan()
                .Not.LazyLoad()
                .AsSet()
                .Fetch.Join()
                .Inverse();
        }
    }
}