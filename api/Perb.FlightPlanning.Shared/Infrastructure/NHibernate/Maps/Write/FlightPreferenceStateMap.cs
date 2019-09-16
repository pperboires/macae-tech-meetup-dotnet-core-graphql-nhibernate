using System;
using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.Framework.Infrastructure.NHibernate;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Write
{
    public class FlightPreferenceStateMap : ClassMap<FlightPreferenceState>
    {
        public FlightPreferenceStateMap()
        {
            Schema("Core");
            
            Table("FlightPreference");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.DayOfWeek).AsEnumString<DayOfWeek>();
          
            Map(x => x.Start, "StartDate");
            Map(x => x.End, "EndDate");
            
            
            References(x => x.MarineUnit, "MarineUnitId");
        }
    }
}