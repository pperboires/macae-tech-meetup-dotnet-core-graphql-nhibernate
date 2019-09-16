using System;
using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Read.Models;
using Perb.Framework.Infrastructure.NHibernate;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Read
{
    public class PlannedFlightModelMap : ClassMap<PlannedFlightModel>
    {
        public PlannedFlightModelMap()
        {
            ReadOnly();
            
            Schema("Core");
            
            Table("PlannedFlight");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.DayOfWeek).AsEnumString<DayOfWeek>();
          
            Map(x => x.Start, "StartDate");
            Map(x => x.End, "EndDate");
            Map(x => x.Seats);
            
            References(x => x.AircraftContract, "AircraftContractId"); 
            References(x => x.MarineUnit, "MarineUnitId");

            References(x => x.Solution, "SolutionId");
        }
    }
}