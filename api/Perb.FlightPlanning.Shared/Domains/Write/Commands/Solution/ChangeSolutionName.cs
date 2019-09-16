using Perb.Framework.Domains.Write.Commands;

namespace Perb.FlightPlanning.Shared.Domains.Write.Commands.Planning
{
    public class ChangeSolutionName : AggregateCommand
    {
        public string Name { get; set; }
    }
}