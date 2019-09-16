using System.Collections.Generic;
using Perb.FlightPlanning.Shared.Domains.Write.Entities;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Domains.Write.Commands;

namespace Perb.FlightPlanning.Shared.Domains.Write.Commands.MarineUnit
{
    public class AddMarineUnit : AggregateCommand
    {
        public string Name { get; set; }
        public int Demand { get; set; }
        public IList<FlightDuration> FlightDurations { get; set; } = new List<FlightDuration>();
        public IList<FlightPreference> FlightPreferences { get; set; } = new List<FlightPreference>();
    }
}