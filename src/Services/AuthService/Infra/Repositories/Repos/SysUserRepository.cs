using AuthService.Infra.Entities;
using AuthService.Infra.Repositories.@interface;
using Shared.Db.Base;
using SqlSugar;

namespace AuthService.Infra.Repositories.Repos
{
    public class SysUserRepository : BaseRepository<SysUser>, ISysUserRepository
    {
        public SysUserRepository(ISqlSugarClient db) : base(db) { }

        public async Task<SysUser?> GetByUserNameAsync(string userName)
        {
            return await _db.Queryable<SysUser>()
                .Where(x => x.UserName == userName && !x.IsDeleted)
                .FirstAsync();
        }
    }
}
