using System;
using FluentNHibernate.Mapping;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.Framework.Infrastructure.NHibernate;

namespace Perb.FlightPlanning.Shared.Infrastructure.NHibernate.Maps.Write
{
    public class PlannedFlightStateMap : ClassMap<PlannedFlightState>
    {
        public PlannedFlightStateMap()
        {
            Schema("Core");
            
            Table("PlannedFlight");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.DayOfWeek).AsEnumString<DayOfWeek>();
          
            Map(x => x.Start, "StartDate");
            Map(x => x.End, "EndDate");
            Map(x => x.Seats);
            Map(x => x.AircraftContractId); 
            Map(x => x.MarineUnitId);

            References(x => x.Solution, "SolutionId");
        }
    }
}