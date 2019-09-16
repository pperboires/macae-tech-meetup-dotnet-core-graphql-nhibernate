using System;
using FluentNHibernate.Mapping;
using NHibernate.Type;
using Perb.FlightPlanning.Shared.Domains.Read.Models;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Infrastructure.NHibernate;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Read
{
    public class PlanningModelMap : ClassMap<PlanningModel>
    {
        public PlanningModelMap()
        {
            ReadOnly();
            
            Schema("Core");
            
            Table("Planning");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Name);
            Map(x => x.Comments);
           
            Map(x => x.FirstFlight);
            Map(x => x.LastFlight);
            Map(x => x.LastFlightType).AsEnumString<LastFlightType>();

            References(x => x.Airport, "AirportId");
            
            HasMany(x => x.DaysOfWeek)
                .Schema("Core")
                .Table("PlanningDayOfWeek")
                .KeyColumn("PlanningId")
                .Element("DayOfWeek", x => x.Type<EnumStringType<DayOfWeek>>());

            HasManyToMany(x => x.MarineUnits)
                .Schema("Core")
                .Table("PlanningMarineUnit")
                .ParentKeyColumn("PlanningId")
                .ChildKeyColumn("MarineUnitId");
            
            HasMany(x => x.AircraftContracts)
                .KeyColumn("PlanningId")
                .Cascade.AllDeleteOrphan()
                .Not.LazyLoad()
                .AsSet()
                .Fetch.Join()
                .Inverse();
        }
    }
}