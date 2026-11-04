using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    /// <summary>
    /// 封装统一返回体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T>
    {
        ///</summary>
        /// 业务状态码0成功1001用户未登录1002没有权限1003参数错误1004用户名或密码错误1005账号已禁用1006刷新令牌过期500服务器内部错误
        /// </summary>
        public int Code { get; set; }

        /// <summary>提示信息</summary>
        public string Message { get; set; } = "ok";

        /// <summary>业务数据</summary>
        public T? Data { get; set; }

        /// <summary>是否成功（前端可直接判断）</summary>
        public bool Success => Code == 0;

        /// <summary>服务端时间戳（毫秒）</summary>
        public long Timestamp { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        public static ApiResult<T> Ok(T data, string message = "ok")
            => new() { Code = 0, Message = message, Data = data };

        public static ApiResult<T> Fail(int code, string message)
            => new() { Code = code, Message = message };
    }
    /// <summary>
    /// 封装统一返回体
    /// </summary>
    public class ApiResult
    {
        /// <summary>业务状态码，0 = 成功</summary>
        public int Code { get; set; }

        /// <summary>提示信息</summary>
        public string Message { get; set; } = "ok";

        /// <summary>是否成功（前端可直接判断）</summary>
        public bool Success => Code == 0;

        /// <summary>服务端时间戳（毫秒）</summary>
        public long Timestamp { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        /// <summary>成功</summary>
        public static ApiResult Ok(string message = "ok")
        {
            return new ApiResult { Code = 0, Message = message };
        }


        /// <summary>失败</summary>
        public static ApiResult Fail(int code, string message)
        {
            return new ApiResult { Code = code, Message = message };
        }
    }

}
