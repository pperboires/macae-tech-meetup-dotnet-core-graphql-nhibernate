using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Read
{
    public class SolutionModelMap : ClassMap<SolutionModel>
    {
        public SolutionModelMap()
        {
            ReadOnly();
            
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
                .KeyColumn("SolutionId");
        }
    }
}