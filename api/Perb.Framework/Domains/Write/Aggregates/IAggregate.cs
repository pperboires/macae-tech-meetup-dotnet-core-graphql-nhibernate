using System;
using Perb.Framework.Domains.Write.States;

namespace Perb.Framework.Domains.Write.Aggregates
{
    public interface IAggregate<out TState> where TState : IState
    {
        Guid Id { get; }
        TState GetState();
    }
}