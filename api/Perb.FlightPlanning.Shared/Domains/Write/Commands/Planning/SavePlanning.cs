using System;
using System.Collections.Generic;
using Perb.FlightPlanning.Shared.Domains.Write.Entities;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Domains.Write.Commands;

namespace Perb.FlightPlanning.Shared.Domains.Write.Commands.Planning
{
    public class SavePlanning : AggregateCommand
    {   
        public string Name { get; set; }
        public Guid AirportId { get; set; }
        public TimeSpan FirstFlight { get; set; }
        public TimeSpan LastFlight { get; set; }
        public LastFlightType LastFlightType { get; set; }
        public IList<DayOfWeek> DaysOfWeek { get; set; } = new List<DayOfWeek>();
        public string Comments { get; set; }
        public IList<Guid> MarineUnitIds { get; set; } = new List<Guid>();
        public IList<AircraftContract> AircraftContracts { get; set; } = new List<AircraftContract>();
    }
}