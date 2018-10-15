// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 

namespace Mondol.FileService.Db.Options
{
    public class DbOption
    {
        public DatabaseType DbType { get; set; }
        public string MasterConnectionString { get; set; }
        /// <summary>
        /// File表的分表个数
        /// </summary>
        public uint FileTableCount { get; set; }
    }

    public enum DatabaseType
    {
        MySql = 1,
        SqlServer = 2
    }
}
