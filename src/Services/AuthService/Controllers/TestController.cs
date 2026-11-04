using Dm.filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Db.Base;

namespace AuthService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IRedisService _redis;

        public TestController(IRedisService redis)
        {
            _redis=redis;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto">登录参数</param>
        /// <returns>JWT Token</returns>
        [HttpPost("login")]
        public IActionResult Login()
        {
            _redis.SetAsync("1","2",TimeSpan.FromMinutes(10));
            return Ok(new { token = "xxx" });
        }

        /// <summary>
        /// 刷新 Token
        /// </summary>
        [HttpPost("refresh")]
        public IActionResult Refresh()
        {
            return Ok();
        }
    }
}
