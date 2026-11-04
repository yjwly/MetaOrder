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

        public async Task BeginTransactionAsync()
        {
            await _db.Ado.BeginTranAsync();
        }

        public async Task CommitAsync()
        {
            await _db.Ado.CommitTranAsync();
        }

        public async Task RollbackAsync()
        {
            await _db.Ado.RollbackTranAsync();
        }
    }
}
