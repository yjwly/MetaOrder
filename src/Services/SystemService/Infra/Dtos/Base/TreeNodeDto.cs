namespace SystemService.Infra.Dtos.Base
{
    /// <summary>
    /// 树形节点
    /// </summary>
    public class TreeNodeDto
    {
        /// <summary>节点ID</summary>
        public long Id { get; set; }

        /// <summary>节点名称</summary>
        public string Name { get; set; } = "";

        /// <summary>节点类型：user/role</summary>
        public string Type { get; set; } = "";

        /// <summary>子节点</summary>
        public List<TreeNodeDto> Children { get; set; } = new();
    }
}
