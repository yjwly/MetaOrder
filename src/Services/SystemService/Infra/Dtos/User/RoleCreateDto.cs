namespace SystemService.Infra.Dtos.User
{
    /// <summary>
    /// 角色创建入参
    /// </summary>
    public class RoleCreateDto
    {
        /// <summary>角色编码</summary>
        public string? Code { get; set; } = "";

        /// <summary>角色名称</summary>
        public string? Name { get; set; } = "";

        /// <summary>数据范围：1全部 2本公司及子 3本公司 4本部门 5自定义</summary>
        public int DataScope { get; set; } = 3;

        /// <summary>备注</summary>
        public string? Remark { get; set; }
    }
}
