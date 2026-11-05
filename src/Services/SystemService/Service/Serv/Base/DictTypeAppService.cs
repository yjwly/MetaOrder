using SqlSugar;
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

        /// <summary>
        /// 添加字典类型
        /// </summary>
        public async Task<long> AddAsync(string name, string code)
        {
            var dictType = new SysDictType
            {
                Id = SnowFlakeSingle.instance.getID(),
                Name = name,
                Code = code,
                CreatedTime = DateTime.Now
            };
            await _dictTypeRepo.AddAsync(dictType);
            return dictType.Id;
        }

        /// <summary>
        /// 修改字典类型
        /// </summary>
        public async Task<bool> UpdateAsync(long id, string name, string code)
        {
            var dictType = await _dictTypeRepo.GetByIdAsync(id);
            if (dictType == null)
                return false;

            dictType.Name = name;
            dictType.Code = code;
            dictType.UpdatedTime = DateTime.Now;
            return await _dictTypeRepo.UpdateAsync(dictType);
        }

        /// <summary>
        /// 删除字典类型
        /// </summary>
        public async Task<bool> DeleteAsync(long id)
        {
            return await _dictTypeRepo.DeleteAsync(id);
        }

    }
}
