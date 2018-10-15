using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Mondol.FileService.Db.Entities;
using Mondol.FileService.Db.Options;

namespace Mondol.FileService.Db
{
    /// <summary>
    /// 主数据读写上下文
    /// </summary>
    internal class MasterDbContext : IDisposable
    {
        private System.Data.IDbConnection _conn;

        public MasterDbContext(IOptionsMonitor<DbOption> dbOption)
        {
            var opt = dbOption.CurrentValue;
            switch (opt.DbType)
            {
                case DatabaseType.MySql:
                    _conn = new MySql.Data.MySqlClient.MySqlConnection(opt.MasterConnectionString);
                    break;
                case DatabaseType.SqlServer:
                    _conn = new System.Data.SqlClient.SqlConnection(opt.MasterConnectionString);
                    break;
                default:
                    throw new NotSupportedException("not suupported DbType " + opt.DbType);
            }
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                    _conn.Close();
                _conn.Dispose();
                _conn = null;
            }
        }

        public IDbConnection Connection
        {
            get
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();
                return _conn;
            }
        }
    }
}
