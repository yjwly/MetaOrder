namespace SystemService.Infra.Dtos.Base
{
    /// <summary>
    /// 字典树节点
    /// </summary>
    public class DictTreeDto
    {
        /// <summary>节点ID</summary>
        public long Id { get; set; }

        /// <summary>节点名称</summary>
        public string Name { get; set; } = "";

        /// <summary>节点类型：type/item</summary>
        public string Type { get; set; } = "";

        /// <summary>字典项值</summary>
        public string? Value { get; set; }

        /// <summary>子节点</summary>
        public List<DictTreeDto> Children { get; set; } = new();
    }
}
