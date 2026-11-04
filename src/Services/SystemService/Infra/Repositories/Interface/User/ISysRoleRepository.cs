using Shared.Db.Base;
using SystemService.Infra.Entities;
using SystemService.Infra.QueryDtos.User;

namespace SystemService.Infra.Repositories.Interface.User
{
    /// <summary>
    /// 角色创建
    /// </summary>
    public interface ISysRoleRepository : IBaseRepository<SysRole>
    {
        /// <summary>
        /// 分页查询角色列表
        /// </summary>
        Task<List<SysRole>> GetPagedListAsync(RoleQueryDto dto);

        /// <summary>
        /// 总数
        /// </summary>
        Task<int> GetCountAsync(RoleQueryDto dto);

        /// <summary>
        /// 根据角色编码查角色
        /// </summary>
        Task<SysRole?> GetByCodeAsync(string code);
    }
}
