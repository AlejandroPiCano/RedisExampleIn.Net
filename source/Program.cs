using StackExchange.Redis;
using System.Net;
using UsingRedisConsoleApp;

namespace source
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key, value;
            var redisDB = RedisDB.Connection.GetDatabase();

            // Setting the keys/values
            Console.WriteLine("Please enter the keys/values or type 'Exit' for finish");

            while (true)
            {
                Console.WriteLine("Please enter the key");
                key = Console.ReadLine();

                if (key.ToLower().Contains("exit"))
                    break;

                Console.WriteLine("Please enter the value");
                value = Console.ReadLine();

                if (key.ToLower().Contains("exit"))
                    break;

                redisDB.StringSet(key, value);
            }

            // Get the value
            while (true)
            {
                Console.WriteLine("Please enter the key for get the value or type 'Exit' for finish");
                key = Console.ReadLine();

                if (key.ToLower().Contains("exit"))
                    break;

                value = redisDB.StringGet(key);

                if (string.IsNullOrEmpty(value))
                    Console.WriteLine("The value can not found");
                else
                    Console.WriteLine($"The value is {value}");                             
            }

            Console.WriteLine("Type 'keys' for get all the keys");
            key = Console.ReadLine();

            // Get all keys
            if (key.ToLower().Contains("keys"))
            {
                EndPoint endPoint = RedisDB.Connection.GetEndPoints().First();
                RedisKey[] keys = RedisDB.Connection.GetServer(endPoint).Keys(pattern: "*").ToArray();

                foreach (var redisKey in keys)
                {
                    Console.WriteLine(redisKey);
                } 
            }

            Console.ReadLine();
        }
    }
}