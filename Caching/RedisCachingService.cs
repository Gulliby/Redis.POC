using System.Linq;
using StackExchange.Redis;
using Infrastructure.Common.Helpers;

namespace Caching
{
    public class RedisCachingService : ICachingService
    {
        private readonly IDatabase _database;
        private readonly CustomJsonSerializer _jsonSerializer;

        public RedisCachingService(IConnectionMultiplexer connectionMultiplexer, CustomJsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
            _database = connectionMultiplexer.GetDatabase();
        }

        public long Delete(params string[] keys)
        {
            return _database.KeyDelete(keys.Select(key => (RedisKey)key).ToArray());
        }

        public bool IsKeyExists(string key)
        {
            return _database.KeyExists(key);
        }

        public T GetValue<T>(string key)
        {
            var value = _database.StringGet(key);

            return _jsonSerializer.Deserialize<T>(value);
        }

        public T SetValue<T>(string key, T value)
        {
            var serializedValue = _jsonSerializer.Serialize(value);

            var oldValue = _database.StringGetSet(key, serializedValue);

            return _jsonSerializer.Deserialize<T>(oldValue);
        }
    }
}
