using SharedKernel;
using SqlSugar;

namespace AuthService.Infra.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    [SugarTable("sys_user")]
    public class SysUser : TenantEntity
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        public string UserName { get; set; } = "";

        /// <summary>
        /// 密码哈希
        /// </summary>
        public string PasswordHash { get; set; } = "";

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; } = "";

        /// <summary>
        /// 手机号
        /// </summary>
        public string? Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public long? DeptId { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string? Avatar { get; set; }

        /// <summary>
        /// 状态：0禁用 1启用
        /// </summary>
        public int Status { get; set; } = 1;

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string? LastLoginIp { get; set; }
    }
}
