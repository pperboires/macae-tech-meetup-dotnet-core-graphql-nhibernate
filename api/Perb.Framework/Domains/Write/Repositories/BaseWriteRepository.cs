using System;
using System.Collections.Generic;
using Perb.Framework.Domains.Write.Aggregates;
using Perb.Framework.Domains.Write.States;
using Perb.Framework.Infrastructure;

namespace Perb.Framework.Domains.Write.Repositories
{
    public abstract class BaseWriteRepository<TAggregate, TState> where TAggregate : IAggregate<TState> where TState : IState
    {
        private readonly IUnitOfWork _unitOfWork;

        protected BaseWriteRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TAggregate GetById(Guid aggregateId)
        {
            var state = _unitOfWork.GetById<TState>(aggregateId);
            if (state != null)
            {
                return CreateAggregate(state);
            }

            return default(TAggregate);
        }

        public void Save(TAggregate aggregate)
        {
            _unitOfWork.Save(aggregate.GetState());
        }

        public void DeleteByIds(IList<Guid> aggregateIds)
        {
            _unitOfWork.RemoveByIds<TState>(aggregateIds);
        }

        protected abstract TAggregate CreateAggregate(TState state);
    }
}