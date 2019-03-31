using System;
using System.Collections.Generic;

namespace DesignPatterns.Singleton
{
    public sealed class LoadBalancer
    {
        // Type-safe generic list of servers
        private readonly IList<Server> _servers;
        private readonly Random _random = new Random();
        
        private LoadBalancer()
        {
            _servers = new List<Server> 
            { 
                new Server{ Name = "ServerI", Ip = "120.14.220.18" },
                new Server{ Name = "ServerII", Ip = "120.14.220.19" },
                new Server{ Name = "ServerIII", Ip = "120.14.220.20" },
                new Server{ Name = "ServerIV", Ip = "120.14.220.21" },
                new Server{ Name = "ServerV", Ip = "120.14.220.22" },
            };
        }
        
        private static readonly Lazy<LoadBalancer> Lazy = new Lazy<LoadBalancer>(() => new LoadBalancer());

        public static LoadBalancer Instance => Lazy.Value;
        
        public Server NextServer
        {
            get
            {
                var r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }
    }
}