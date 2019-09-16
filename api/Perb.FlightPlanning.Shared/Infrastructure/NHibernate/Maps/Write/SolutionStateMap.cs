using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Write
{
    public class SolutionStateMap : ClassMap<SolutionState>
    {
        public SolutionStateMap()
        {
            Schema("Core");
            
            Table("Solution");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Name);
            Map(x => x.Date);
            Map(x => x.PlanningId);
          
            Component(a => a.Score, b =>
            {
                b.Map(c => c.Soft).Column("ScoreSoft");
                b.Map(c => c.Medium).Column("ScoreMedium");
                b.Map(c => c.Hard).Column("ScoreHard");
            });

            HasMany(x => x.PlannedFlights)
                .KeyColumn("SolutionId")
                .Cascade.AllDeleteOrphan()
                .Inverse();
        }
    }
}