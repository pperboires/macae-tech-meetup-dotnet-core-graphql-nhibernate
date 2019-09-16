using System;
using Perb.Framework.Infrastructure;

namespace Perb.Framework.Domains.Read
{
    public class BaseModel : IIdentifiable
    {
        public Guid Id { get; set; }
    }
}