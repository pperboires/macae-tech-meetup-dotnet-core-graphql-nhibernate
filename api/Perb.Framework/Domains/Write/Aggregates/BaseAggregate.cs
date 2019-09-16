using System;
using Perb.Framework.Domains.Write.States;

namespace Perb.Framework.Domains.Write.Aggregates
{
    public abstract class BaseAggregate<TState> : IAggregate<TState> where TState : IState
    {
        protected TState State;
        
        protected BaseAggregate(TState state)
        {
            State = state;
        }

        protected BaseAggregate()
        {
            
        }

        public Guid Id => State.Id;
        
        public TState GetState()
        {
            return State;
        }
    }
}