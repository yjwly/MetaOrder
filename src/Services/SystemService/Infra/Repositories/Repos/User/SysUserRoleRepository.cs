using Shared.Db.Base;
using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface;
using SystemService.Infra.Repositories.Interface.User;

namespace SystemService.Infra.Repositories.Repos.User
{
    /// <summary>
    /// 用户角色关联仓储实现
    /// </summary>
    public class SysUserRoleRepository :  ISysUserRoleRepository
    {
        private readonly ISqlSugarClient _db;

        public SysUserRoleRepository(ISqlSugarClient db)
        {
            _db = db;
        }

        /// <summary>
        /// 根据用户ID查角色ID列表
        /// </summary>
        public async Task<List<long>> GetRoleIdsByUserIdAsync(long userId)
        {
            return await _db.Queryable<SysUserRole>()
                .Where(x => x.UserId == userId)
                .Select(x => x.RoleId)
                .ToListAsync();
        }

        /// <summary>
        /// 根据用户ID删除所有角色
        /// </summary>
        public async Task DeleteByUserIdAsync(long userId)
        {
            await _db.Deleteable<SysUserRole>()
                .Where(x => x.UserId == userId)
                .ExecuteCommandAsync();
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        public async Task AddRangeAsync(List<SysUserRole> list)
        {
            await _db.Insertable(list).ExecuteCommandAsync();
        }
    }
}