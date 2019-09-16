using System;
using System.Collections.Generic;

namespace Perb.Framework.Domains.Write.Commands
{
    public abstract class MultiAggregateCommand : Command
    {
        public IList<Guid> AggregateIds { get; set; } = new List<Guid>();
    }
}