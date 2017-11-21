using System;
using System.Linq;
using StackExchange.Redis;

namespace Caching.Services
{
    public class RedisCachingService : ICachingService
    {
        private readonly IDatabase _database;

        public RedisCachingService(IConnectionMultiplexer connectionMultiplexer)
        {
            _database = connectionMultiplexer.GetDatabase();
        }

        public void Delete(params string[] keys)
        {
            _database.KeyDelete(keys.Select(key => (RedisKey)key).ToArray());
        }

        public string GetValue(string key)
        {
            return _database.StringGet(key);
        }

        public void SetValue(string key, string value)
        {
            _database.StringSet(key, value);
        }
    }
}