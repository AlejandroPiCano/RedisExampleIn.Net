using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace UsingRedisConsoleApp
{
    internal static class RedisDB
    {
        private static Lazy<ConnectionMultiplexer> lazyConnnection = new Lazy<ConnectionMultiplexer>(() =>
                                     ConnectionMultiplexer.Connect("localhost"));

        public static ConnectionMultiplexer Connection { get => lazyConnnection.Value; }      
    }
}
