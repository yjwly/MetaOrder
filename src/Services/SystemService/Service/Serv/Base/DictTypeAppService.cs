using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Base;
using SystemService.Service.Interface.Base;

namespace SystemService.Service.Serv.Base
{
    /// <summary>
    /// 字典类型服务实现
    /// </summary>
    public class DictTypeAppService : IDictTypeAppService
    {
        private readonly ISysDictTypeRepository _dictTypeRepo;

        public DictTypeAppService(ISysDictTypeRepository dictTypeRepo)
        {
            _dictTypeRepo = dictTypeRepo;
        }

        /// <summary>
        /// 查询所有字典类型列表
        /// </summary>
        public async Task<List<SysDictType>> GetListAsync()
        {
            return await _dictTypeRepo.GetListAsync(x => true);
        }
    }
}
