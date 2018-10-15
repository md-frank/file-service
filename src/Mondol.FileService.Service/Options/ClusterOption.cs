// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
namespace Mondol.FileService.Service.Options
{
    /// <summary>
    /// 集群选项
    /// </summary>
    public class ClusterOption
    {
        /// <summary>
        /// 本服务器的ID
        /// </summary>
        public int SelfServerId { get; set; }
        public Server[] Servers { get; set; }
    }

    public class Server
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public int Weight { get; set; }
        public bool AllowUpload { get; set; }
    }
}
