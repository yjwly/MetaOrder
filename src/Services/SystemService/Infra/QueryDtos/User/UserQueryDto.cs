using SharedKernel;

namespace SystemService.Infra.QueryDtos.User
{
    /// <summary>
    /// 用户查询参数
    /// </summary>
    public class UserQueryDto:PagedQuery
    {
        /// <summary>用户名</summary>
        public string? UserName { get; set; }

        /// <summary>状态</summary>
        public int? Status { get; set; }
    }
}
