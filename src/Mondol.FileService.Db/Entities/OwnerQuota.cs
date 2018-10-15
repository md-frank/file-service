// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-12-13
// 
namespace Mondol.FileService.Db.Entities
{
    /// <summary>
    /// 文件所有者配额信息
    /// </summary>
    public class OwnerQuota
    {
        public long Id { get; set; }
        public int OwnerType { get; set; }
        public long OwnerId { get; set; }
        public long Used { get; set; }
        public long Max { get; set; }
    }
}
