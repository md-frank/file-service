// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System.Collections.Generic;
using System.Net;

namespace Mondol.FileService.Options
{
    public class ManageOption
    {
        private static Dictionary<string, object> _localIpAddresses;
        private static readonly object LocalIpAddressesLock = new object();

        public string[] IpWhitelist { get; set; }

        /// <summary>
        /// 判断指定IP是否是本机IP
        /// </summary>
        public bool IsLocalIp(string ip)
        {
            Dictionary<string, object> localIps = null;
            lock (LocalIpAddressesLock)
            {
                if (_localIpAddresses == null)
                {
                    //var hostAddrs = Dns.GetHostAddressesAsync(Dns.GetHostName()).Result;
                    //_localIpAddresses = new Dictionary<string, object>(hostAddrs.Length + 2);
                    //foreach (var hostAddr in hostAddrs)
                    //{
                    //    _localIpAddresses[hostAddr.ToString()] = null;
                    //}

                    _localIpAddresses = new Dictionary<string, object>
                    {
                        [IPAddress.Loopback.ToString()] = null,
                        [IPAddress.IPv6Loopback.ToString()] = null
                    };
                }
                localIps = _localIpAddresses;
            }

            return localIps.ContainsKey(ip);
        }
    }
}
