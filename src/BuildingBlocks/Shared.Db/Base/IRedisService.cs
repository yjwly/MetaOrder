using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Db.Base
{
    /// <summary>
    /// redis接口
    /// </summary>
    public interface IRedisService
    {
        Task<string?> GetAsync(string key);
        Task SetAsync(string key, string value, TimeSpan ttl);
        Task<bool> RemoveAsync(string key);
        Task<IDisposable?> LockAsync(string key, int ttlSeconds = 10);
    }
}
