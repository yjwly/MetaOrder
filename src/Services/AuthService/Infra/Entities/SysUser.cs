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
        /// <summary>登录账号</summary>
        [SugarColumn(ColumnName = "user_name")]
        public string UserName { get; set; } = "";

        /// <summary>密码哈希</summary>
        [SugarColumn(ColumnName = "password_hash")]
        public string PasswordHash { get; set; } = "";
        /// <summary>
        /// 公司ID
        /// </summary>
        [SugarColumn(ColumnName = "company_id")]
        public long CompanyId { get; set; }
        /// <summary>真实姓名</summary>
        [SugarColumn(ColumnName = "real_name")]
        public string RealName { get; set; } = "";

        /// <summary>手机号</summary>
        [SugarColumn(ColumnName = "mobile")]
        public string? Mobile { get; set; }

        /// <summary>邮箱</summary>
        [SugarColumn(ColumnName = "email")]
        public string? Email { get; set; }

        /// <summary>部门ID</summary>
        [SugarColumn(ColumnName = "dept_id")]
        public long? DeptId { get; set; }

        /// <summary>头像</summary>
        [SugarColumn(ColumnName = "avatar")]
        public string? Avatar { get; set; }

        /// <summary>状态：0禁用 1启用</summary>
        [SugarColumn(ColumnName = "status")]
        public int Status { get; set; } = 1;

        /// <summary>最后登录时间</summary>
        [SugarColumn(ColumnName = "last_login_time")]
        public DateTime? LastLoginTime { get; set; }

        /// <summary>最后登录IP</summary>
        [SugarColumn(ColumnName = "last_login_ip")]
        public string? LastLoginIp { get; set; }
    }
}
