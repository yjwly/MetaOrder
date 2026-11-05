using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.User;

namespace SystemService.Infra.Repositories.Repos.User
{
    /// <summary>
    /// 角色权限关联仓储实现
    /// </summary>
    public class SysRolePermissionRepository : ISysRolePermissionRepository
    {
        private readonly ISqlSugarClient _db;

        public SysRolePermissionRepository(ISqlSugarClient db)
        {
            _db = db;
        }

        /// <summary>
        /// 根据角色ID查菜单ID列表
        /// </summary>
        public async Task<List<long>> GetMenuIdsByRoleIdAsync(long roleId)
        {
            return await _db.Queryable<SysRolePermission>()
                .Where(x => x.RoleId == roleId && x.MenuId > 0)
                .Select(x => x.MenuId)
                .ToListAsync();
        }

        /// <summary>
        /// 根据角色ID查按钮ID列表
        /// </summary>
        public async Task<List<long>> GetButtonIdsByRoleIdAsync(long roleId)
        {
            return await _db.Queryable<SysRolePermission>()
                .Where(x => x.RoleId == roleId && x.ButtonId > 0)
                .Select(x => x.ButtonId)
                .ToListAsync();
        }

        /// <summary>
        /// 根据角色ID删除所有权限
        /// </summary>
        public async Task DeleteByRoleIdAsync(long roleId)
        {
            await _db.Deleteable<SysRolePermission>()
                .Where(x => x.RoleId == roleId)
                .ExecuteCommandAsync();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        public async Task AddRangeAsync(List<SysRolePermission> list)
        {
            await _db.Insertable(list).ExecuteCommandAsync();
        }
    }
}
