using SharedKernel;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Db.Base
{
    public class BaseRepository<T> where T : TenantEntity, new()
    {
        protected readonly ISqlSugarClient _db;
        public BaseRepository(ISqlSugarClient db) => _db = db;

        public virtual ISugarQueryable<T> Query() => _db.Queryable<T>();
        public virtual async Task<T?> GetByIdAsync(long id) =>
            await _db.Queryable<T>().InSingleAsync(id);
        public virtual async Task<List<T>> GetListAsync(Expression<Func<T, bool>> where) =>
            await _db.Queryable<T>().Where(where).ToListAsync();
        public virtual async Task<PageModel<T>> GetPageAsync(
            int pageIndex, int pageSize,
            Expression<Func<T, bool>>? where = null)
        {
            RefAsync<int> total = 0;
            var list = await _db.Queryable<T>()
                .WhereIF(where != null, where)
                .OrderBy(x => x.Id, OrderByType.Desc)
                .ToPageListAsync(pageIndex, pageSize, total);
            return new PageModel<T> { List = list, Total = total };
        }
        public virtual async Task<long> AddAsync(T entity) =>
            await _db.Insertable(entity).ExecuteReturnSnowflakeIdAsync();
        public virtual async Task<bool> UpdateAsync(T entity) =>
            await _db.Updateable(entity).ExecuteCommandHasChangeAsync();
        public virtual async Task<bool> DeleteAsync(long id) =>
            await _db.Updateable<T>()
                .SetColumns(x => x.IsDeleted == true)
                .Where(x => x.Id == id).ExecuteCommandHasChangeAsync();
    }
    public class PageModel<T> { public List<T> List { get; set; } = new(); public int Total { get; set; } }
}
