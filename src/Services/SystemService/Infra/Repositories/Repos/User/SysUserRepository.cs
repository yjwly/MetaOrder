using Shared.Db.Base;
using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.QueryDtos.User;
using SystemService.Infra.Repositories.Interface.User;

namespace SystemService.Infra.Repositories.Repos.User
{
    /// <summary>
    /// 用户仓储
    /// </summary>
    public class SysUserRepository : BaseRepository<SysUser>, ISysUserRepository
    {
        public SysUserRepository(ISqlSugarClient db) : base(db) { }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<List<SysUser>> GetPagedListAsync(UserQueryDto dto)
        {
            return await _db.Queryable<SysUser>()
                .WhereIF(!string.IsNullOrEmpty(dto.UserName), x => x.UserName.Contains(dto.UserName!))
                .WhereIF(dto.Status != null, x => x.Status == dto.Status)
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.CreatedTime, OrderByType.Desc)
                .ToPageListAsync(dto.PageIndex, dto.PageSize);
        }

        /// <summary>
        /// 查询总数
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<int> GetCountAsync(UserQueryDto dto)
        {
            return await _db.Queryable<SysUser>()
                .WhereIF(!string.IsNullOrEmpty(dto.UserName), x => x.UserName.Contains(dto.UserName!))
                .WhereIF(dto.Status != null, x => x.Status == dto.Status)
                .Where(x => !x.IsDeleted)
                .CountAsync();
        }

        /// <summary>
        /// 根据用户名查询用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<SysUser?> GetByUserNameAsync(string userName)
        {
            return await _db.Queryable<SysUser>()
                .Where(x => x.UserName == userName && !x.IsDeleted)
                .FirstAsync();
        }
    }
}
