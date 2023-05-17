using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Services
{
    public interface IRedisCacheService
    {
        Task<T> GetFromRedis<T>(string key);
        Task<bool> SetToRedis<T>(string key, T value, DateTimeOffset expirationTime);
        Task<bool> RemoveFromRedis(string key);
        Task<bool> SetToRedis<T>(string key, T value);
    }
}
