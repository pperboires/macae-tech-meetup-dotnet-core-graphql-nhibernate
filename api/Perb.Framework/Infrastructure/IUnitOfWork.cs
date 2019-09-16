using System;
using System.Collections.Generic;
using System.Linq;
using Perb.Framework.Domains.Write.States;

namespace Perb.Framework.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();
        void Commit();
        void Rollback();
        IQueryable<T> GetQuery<T>() where T : IIdentifiable;
        T GetById<T>(Guid id) where T : IIdentifiable;
        void Save<T>(T state) where T : IState;
        void RemoveByIds<T>(IList<Guid> ids) where T : IState;
    }
}