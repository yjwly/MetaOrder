using SystemService.Infra.Entities;

namespace SystemService.Service.Interface.Org
{
    /// <summary>
    /// 组织服务接口
    /// </summary>
    public interface IOrgAppService
    {
        /// <summary>
        /// 查询所有组织列表
        /// </summary>
        Task<List<SysOrg>> GetListAsync();

        /// <summary>
        /// 添加组织
        /// </summary>
        Task<long> AddAsync(string name, string code, long parentId, int sort);

        /// <summary>
        /// 修改组织
        /// </summary>
        Task<bool> UpdateAsync(long id, string name, string code, long parentId, int sort);

        /// <summary>
        /// 删除组织
        /// </summary>
        Task<bool> DeleteAsync(long id);
    }
}
