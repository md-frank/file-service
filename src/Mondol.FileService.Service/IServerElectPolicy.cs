// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 

namespace Mondol.FileService.Service
{
    /// <summary>
    /// 服务器选取策略
    /// </summary>
    public interface IServerElectPolicy
    {
        Service.Options.Server ElectServer();
    }
}
