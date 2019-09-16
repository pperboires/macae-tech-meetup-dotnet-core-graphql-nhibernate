using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NHibernate;
using Perb.Framework.Domains.Write.States;
using Perb.Framework.Logging;

namespace Perb.Framework.Infrastructure.NHibernate
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        private static readonly ILog Logger = LogProvider.For<NHibernateUnitOfWork>();
        
        private readonly Func<ISession> _sessionCreator;

        public NHibernateUnitOfWork(Func<ISession> sessionCreator)
        {
            _sessionCreator = sessionCreator;
        }

        public IQueryable<T> GetQuery<T>() where T : IIdentifiable
        {
            return _sessionCreator().Query<T>();
        }

        public T GetById<T>(Guid id) where T : IIdentifiable
        {
            return _sessionCreator().Get<T>(id);
        }

        public void Save<T>(T state) where T : IState
        {
            _sessionCreator().Save(state);
        }

        public void RemoveByIds<T>(IList<Guid> ids) where T : IState
        {
            foreach (var toDelete in _sessionCreator().Query<T>().Where(x => ids.Contains(x.Id)))
            {
                _sessionCreator().Delete(toDelete);
            }
        }

        public void Begin()
        {
            _sessionCreator().BeginTransaction(IsolationLevel.Snapshot);
        }

        public void Commit()
        {
            _sessionCreator().Transaction.Commit();
        }

        public void Rollback()
        {
            _sessionCreator().Transaction.Rollback();
        }

        public void Dispose()
        {   
            var session = _sessionCreator();

            if (session.IsOpen)
            {
                session.Close();
            }    
        }
    }
}