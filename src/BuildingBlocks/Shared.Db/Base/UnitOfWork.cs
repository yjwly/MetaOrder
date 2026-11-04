using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Db.Base
{
    /// <summary>
    /// 工作单元实现
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISqlSugarClient _db;

        public UnitOfWork(ISqlSugarClient db)
        {
            _db = db;
        }

        /// <summary>
        /// 开始业务
        /// </summary>
        /// <returns></returns>
        public async Task BeginTransactionAsync()
        {
            await _db.Ado.BeginTranAsync();
        }

        /// <summary>
        /// 提交业务
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            await _db.Ado.CommitTranAsync();
        }

        /// <summary>
        /// 回滚业务
        /// </summary>
        /// <returns></returns>
        public async Task RollbackAsync()
        {
            await _db.Ado.RollbackTranAsync();
        }
    }
}
