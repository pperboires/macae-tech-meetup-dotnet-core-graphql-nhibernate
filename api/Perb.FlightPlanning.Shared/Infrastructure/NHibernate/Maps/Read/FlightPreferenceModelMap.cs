using System;
using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Read.Models;
using Perb.Framework.Infrastructure.NHibernate;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Read
{
    public class FlightPreferenceModelMap : ClassMap<FlightPreferenceModel>
    {
        public FlightPreferenceModelMap()
        {
            ReadOnly();
            
            Schema("Core");
            
            Table("FlightPreference");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Start, "StartDate");
            Map(x => x.End, "EndDate");
            Map(x => x.DayOfWeek).AsEnumString<DayOfWeek>();

            References(x => x.MarineUnit, "MarineUnitId");
        }
    }
}