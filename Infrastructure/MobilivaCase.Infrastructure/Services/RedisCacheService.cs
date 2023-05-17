using MobilivaCase.Application.Services;

using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Infrastructure.Services
{
    public class RedisCacheService : IRedisCacheService
    {

        IDatabase _cacheDb;

        public RedisCacheService()
        {
            var port = Configuration.RedisPort;
            var redis = ConnectionMultiplexer.Connect(port);
            _cacheDb = redis.GetDatabase();
        }


        public async Task<T> GetFromRedis<T>(string key)
        {
            var result = _cacheDb.StringGet(key);
            if (!string.IsNullOrEmpty(result))
                return System.Text.Json.JsonSerializer.Deserialize<T>(result);

            return default;


        }

        public async Task<bool> RemoveFromRedis(string key)
        {
            if (_cacheDb.KeyExists(key))
                return await _cacheDb.KeyDeleteAsync(key);

            return false;
        }

        public async Task<bool> SetToRedis<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var exipireTime = expirationTime.DateTime.Subtract(DateTime.Now);

            return await _cacheDb.StringSetAsync(key, System.Text.Json.JsonSerializer.Serialize(value), exipireTime);

        }
        public async Task<bool> SetToRedis<T>(string key, T value)
        {

            return await _cacheDb.StringSetAsync(key, System.Text.Json.JsonSerializer.Serialize(value));

        }

    }
}
