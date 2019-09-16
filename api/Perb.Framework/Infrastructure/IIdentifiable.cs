using System;

namespace Perb.Framework.Infrastructure
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}