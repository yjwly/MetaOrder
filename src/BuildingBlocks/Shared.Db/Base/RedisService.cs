using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Db.Base
{

    /// <summary>
    /// redis服务类
    /// </summary>
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisService(IConnectionMultiplexer redis)
        {
            _redis= redis;
        }
        private IDatabase Db => _redis.GetDatabase();
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<string?> GetAsync(string key)
        {
           return await Db.StringGetAsync(key);
        }
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="ttl">过期时间</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task SetAsync(string key, string value, TimeSpan ttl)
        {
             await Db.StringSetAsync(key:key,value:value,ttl);
        }

        /// <summary>
        /// 移除值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> RemoveAsync(string key)
        {
          return  await Db.KeyDeleteAsync(key);
        }

        /// <summary>
        /// 加分布式锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="ttlSeconds"></param>
        /// <returns></returns>
        public async Task<IDisposable?> LockAsync(string key, int ttlSeconds = 10)
        {
            var token = Guid.NewGuid().ToString();
            var ok = await Db.StringSetAsync(key: key, token, TimeSpan.FromSeconds(ttlSeconds), When.NotExists);
            if (!ok) { return null; }
            return new RedisLockReleaser(_redis,key,token);
        }


        /// <summary>
        /// 清楚分布式锁
        /// </summary>
        public class RedisLockReleaser : IDisposable
        {
            public readonly IConnectionMultiplexer _r;
            public readonly string _k, _t;

            public RedisLockReleaser(IConnectionMultiplexer r,string k,string t)
            {
                _r=r;
                _k=k;
                _t=t;
            }
            public void Dispose() => _r.GetDatabase().KeyDelete(_k);

        }

    }


}
