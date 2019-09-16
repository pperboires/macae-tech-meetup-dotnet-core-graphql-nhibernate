using System;

namespace Perb.Framework.Domains.Write.Commands
{
    public abstract class AggregateCommand : Command
    {
        public Guid AggregateId { get; set; }
    }
}