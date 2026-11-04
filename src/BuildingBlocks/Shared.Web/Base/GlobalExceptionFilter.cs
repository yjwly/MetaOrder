using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Web.Base
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class GlobalExceptionFilter : IAsyncExceptionFilter
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;

            // 记录日志
            Log.Error(exception, "全局异常：{Message}", exception.Message);

            // 返回统一错误格式
            context.Result = new ObjectResult(new ApiResult
            {
                Code = 500,
                Message = exception.Message
            })
            {
                StatusCode = 200
            };

            context.ExceptionHandled = true;

            await Task.CompletedTask;
        }
    }
}
