using System;
using FluentNHibernate.Mapping;
using NHibernate.Criterion;
using NHibernate.Type;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Infrastructure.NHibernate;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Write
{
    public class PlanningStateMap : ClassMap<PlanningState>
    {
        public PlanningStateMap()
        {
            Schema("Core");
            
            Table("Planning");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Name);
            Map(x => x.Comments);
            Map(x => x.AirportId);
            Map(x => x.FirstFlight);
            Map(x => x.LastFlight);
            Map(x => x.LastFlightType).AsEnumString<LastFlightType>();

            HasMany(x => x.DaysOfWeek)
                .Schema("Core")
                .Table("PlanningDayOfWeek")
                .KeyColumn("PlanningId")
                .Element("DayOfWeek", x => x.Type<EnumStringType<DayOfWeek>>());

            HasMany(x => x.MarineUnitIds)
                .Schema("Core")
                .Table("PlanningMarineUnit")
                .KeyColumn("PlanningId")
                .Element("MarineUnitId");
            
            HasMany(x => x.AircraftContracts)
                .KeyColumn("PlanningId")
                .Cascade.AllDeleteOrphan()
                .Inverse();
        }
    }
}