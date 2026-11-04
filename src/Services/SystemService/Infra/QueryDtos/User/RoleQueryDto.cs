using SharedKernel;

namespace SystemService.Infra.QueryDtos.User
{
    /// <summary>
    /// 角色查询参数
    /// </summary>
    public class RoleQueryDto:PagedQuery
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int? Status { get; set; }
    }
}
