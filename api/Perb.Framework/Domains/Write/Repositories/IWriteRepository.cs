using System;
using System.Collections.Generic;
using Perb.Framework.Domains.Write.Aggregates;
using Perb.Framework.Domains.Write.States;

namespace Perb.Framework.Domains.Write.Repositories
{
    public interface IWriteRepository<TAggregate, TState> where TAggregate : IAggregate<TState> where TState : IState
    {
        TAggregate GetById(Guid aggregateId);
        void Save(TAggregate aggregate);
        void DeleteByIds(IList<Guid> aggregateIds);
    }
}