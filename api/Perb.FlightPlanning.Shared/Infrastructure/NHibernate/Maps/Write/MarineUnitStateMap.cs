using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Write
{
    public class MarineUnitStateMap : ClassMap<MarineUnitState>
    {
        public MarineUnitStateMap()
        {
            Schema("Core");
            
            Table("MarineUnit");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Name);
            Map(x => x.Demand);
            
            HasMany(x => x.FlightDurations)
                .KeyColumn("MarineUnitId")
                .Cascade.AllDeleteOrphan()
                .Inverse();

            HasMany(x => x.FlightPreferences)
                .KeyColumn("MarineUnitId")
                .Cascade.AllDeleteOrphan()
                .Inverse();
        }
    }
}