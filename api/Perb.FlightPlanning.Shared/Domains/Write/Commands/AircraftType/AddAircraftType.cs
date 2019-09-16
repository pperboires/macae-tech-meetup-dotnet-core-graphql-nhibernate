using System.Collections.Generic;
using Perb.FlightPlanning.Shared.Domains.Write.Entities;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Domains.Write.Commands;

namespace Perb.FlightPlanning.Shared.Domains.Write.Commands.AircraftType
{
    public class AddAircraftType : AggregateCommand
    {   
        public string Code { get; set; }
        public string Name { get; set; }
        public IList<SeatsByFlightDuration> SeatsByDuration { get; set; } = new List<SeatsByFlightDuration>();
    }
}