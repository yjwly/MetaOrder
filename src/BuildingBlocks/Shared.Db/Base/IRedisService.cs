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
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string?> GetAsync(string key);
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="ttl">过期时间</param>
        /// <returns></returns>
        Task SetAsync(string key, string value, TimeSpan ttl);
        /// <summary>
        /// 根据键移除值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<bool> RemoveAsync(string key);

        /// <summary>
        /// 加分布式锁
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="ttlSeconds">过期时间</param>
        /// <returns></returns>
        Task<IDisposable?> LockAsync(string key, int ttlSeconds = 10);
    }
}
