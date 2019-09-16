using System;

namespace Perb.Framework.Domains.Write.States
{
    public class BaseState : IState
    {
        public Guid Id { get; set; }
    }
}