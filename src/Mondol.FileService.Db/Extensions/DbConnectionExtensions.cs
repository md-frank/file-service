using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper
{
    public static class DbConnectionExtensions
    {
        public static EasyTransaction Transaction(this IDbConnection dbConn, IsolationLevel isolation = IsolationLevel.ReadCommitted)
        {
            return new EasyTransaction(dbConn, isolation);
        }
    }
}
