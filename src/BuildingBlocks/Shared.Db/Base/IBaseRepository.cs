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
    public interface IBaseRepository<T> where T : TenantEntity, new()
    {
        ISugarQueryable<T> Query();
        Task<T?> GetByIdAsync(long id);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> where);
        Task<PageModel<T>> GetPageAsync(int pageIndex, int pageSize,
            Expression<Func<T, bool>>? where = null);
        Task<long> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(long id);
    }
}
