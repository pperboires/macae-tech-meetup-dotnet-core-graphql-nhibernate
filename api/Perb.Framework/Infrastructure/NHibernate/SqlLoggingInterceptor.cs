using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Type;
using Perb.Framework.Logging;

namespace Perb.Framework.Infrastructure.NHibernate
{
    public class SqlLoggingInterceptor : EmptyInterceptor
    {
        private static readonly ILog Logger = LogProvider.For<SqlLoggingInterceptor>();
        
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            Logger.DebugFormat("SQL: {sql}.", sql);
            return base.OnPrepareStatement(sql);
        }

        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames,
            IType[] types)
        {
            return base.OnFlushDirty(entity, id, currentState, previousState, propertyNames, types);
        }
    }
}