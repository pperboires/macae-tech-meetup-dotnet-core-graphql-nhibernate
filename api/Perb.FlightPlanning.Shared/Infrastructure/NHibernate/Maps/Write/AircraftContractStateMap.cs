using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Write.States;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Write
{
    public class AircraftContractStateMap : ClassMap<AircraftContractState>
    {
        public AircraftContractStateMap()
        {
            Schema("Core");
            
            Table("AircraftContract");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Name);
            Map(x => x.DailyTime);
            Map(x => x.MaintenanceTime);
            Map(x => x.AircraftTypeId);
            Map(x => x.HasCrewRegulation);

            References(x => x.Planning, "PlanningId");
        }
    }
}