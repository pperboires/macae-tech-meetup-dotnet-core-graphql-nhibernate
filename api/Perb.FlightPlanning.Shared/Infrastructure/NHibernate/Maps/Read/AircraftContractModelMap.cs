using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Read
{
    public class AircraftContractModelMap : ClassMap<AircraftContractModel>
    {
        public AircraftContractModelMap()
        {
            ReadOnly();
            
            Schema("Core");
            
            Table("AircraftContract");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Name);
            Map(x => x.DailyTime);
            Map(x => x.MaintenanceTime);
         
            Map(x => x.HasCrewRegulation);

            References(x => x.AircraftType, "AircraftTypeId");
        }
    }
}