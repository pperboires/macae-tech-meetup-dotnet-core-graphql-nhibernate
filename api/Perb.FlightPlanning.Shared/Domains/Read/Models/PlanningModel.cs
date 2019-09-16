using System;
using System.Collections.Generic;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Domains.Read;

namespace Perb.FlightPlanning.Shared.Domains.Read.Models
{
    public class PlanningModel : BaseModel
    {
        public string Name { get; set; }
        public AirportModel Airport { get; set; }
        public TimeSpan FirstFlight { get; set; }
        public TimeSpan LastFlight { get; set; }
        public LastFlightType LastFlightType { get; set; }
        public IList<DayOfWeek> DaysOfWeek { get; set; }
        public string Comments { get; set; }
        public IEnumerable<MarineUnitModel> MarineUnits { get; set; } = new HashSet<MarineUnitModel>();
        public IEnumerable<AircraftContractModel> AircraftContracts { get; set; } = new HashSet<AircraftContractModel>();
    }
}