using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper
{
    /// <summary>
    ///     Transaction object helps maintain transaction depth counts
    /// </summary>
    public class EasyTransaction : IDisposable
    {
        private IDbTransaction _trans;

        public EasyTransaction(IDbConnection dbConn, IsolationLevel isolation = IsolationLevel.ReadCommitted)
        {
            _trans = dbConn.BeginTransaction(isolation);
        }

        public void Complete()
        {
            _trans.Commit();
            _trans = null;
        }

        public void Dispose()
        {
            if (_trans != null)
            {
                _trans.Rollback();
                _trans = null;
            }
        }
    }
}
