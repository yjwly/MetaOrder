using Shared.Db.Base;
using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.QueryDtos.User;
using SystemService.Infra.Repositories.Interface.User;

namespace SystemService.Infra.Repositories.Repos.User
{
    /// <summary>
    /// 角色仓储
    /// </summary>
    public class SysRoleRepository : BaseRepository<SysRole>, ISysRoleRepository
    {
        public SysRoleRepository(ISqlSugarClient db) : base(db) { }

        /// <summary>
        /// 分页查询角色目录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<List<SysRole>> GetPagedListAsync(RoleQueryDto dto)
        {
            return await _db.Queryable<SysRole>()
                .WhereIF(!string.IsNullOrEmpty(dto.Name), x => x.Name.Contains(dto.Name!))
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.CreatedTime, OrderByType.Desc)
                .ToPageListAsync(dto.PageIndex, dto.PageSize);
        }

        /// <summary>
        /// 统计角色数量
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<int> GetCountAsync(RoleQueryDto dto)
        {
            return await _db.Queryable<SysRole>()
                .WhereIF(!string.IsNullOrEmpty(dto.Name), x => x.Name.Contains(dto.Name!))
                .Where(x => !x.IsDeleted)
                .CountAsync();
        }

        /// <summary>
        /// 根据角色编号查询角色
        /// </summary>
        /// <param name="code">角色编码</param>
        /// <returns></returns>
        public async Task<SysRole?> GetByCodeAsync(string code)
        {
            return await _db.Queryable<SysRole>()
                .Where(x => x.Code == code && !x.IsDeleted)
                .FirstAsync();
        }
    }
}
