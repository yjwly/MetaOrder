using SqlSugar;
using SystemService.Infra.Dtos.Base;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Base;
using SystemService.Service.Interface.Base;

namespace SystemService.Service.Serv.Base
{
    /// <summary>
    /// 字典项服务实现
    /// </summary>
    public class DictItemAppService : IDictItemAppService
    {
        private readonly ISysDictItemRepository _dictItemRepo;
        private readonly ISysDictTypeRepository _dictTypeRepo;

        public DictItemAppService(ISysDictItemRepository dictItemRepo, ISysDictTypeRepository dictTypeRepo)
        {
            _dictItemRepo = dictItemRepo;
            _dictTypeRepo = dictTypeRepo;
        }

        /// <summary>
        /// 根据字典类型ID查字典项列表
        /// </summary>
        public async Task<List<SysDictItem>> GetListByDictTypeIdAsync(long dictTypeId)
        {
            return await _dictItemRepo.GetListByDictTypeIdAsync(dictTypeId);
        }

        /// <summary>
        /// 根据字典类型编码查字典项列表
        /// </summary>
        public async Task<List<SysDictItem>> GetListByDictTypeCodeAsync(string dictTypeCode)
        {
            // 先查字典类型
            var dictType = await _dictTypeRepo.GetListAsync(x => x.Code == dictTypeCode);
            if (dictType == null)
                return new List<SysDictItem>();
            var first= dictType.First();
            // 再查字典项
            return await _dictItemRepo.GetListByDictTypeIdAsync(long.Parse(first.Code));
        }

        /// <summary>
        /// 生成字典树
        /// </summary>
        public async Task<List<DictTreeDto>> GetDictTreeAsync()
        {
            // 查所有字典类型
            var dictTypes = await _dictTypeRepo.GetListAsync(x => true);

            var tree = new List<DictTreeDto>();

            foreach (var dictType in dictTypes)
            {
                var typeNode = new DictTreeDto
                {
                    Id = dictType.Id,
                    Name = dictType.Name,
                    Type = "type"
                };

                // 查这个类型下的字典项
                var items = await _dictItemRepo.GetListByDictTypeIdAsync(dictType.Id);

                foreach (var item in items)
                {
                    typeNode.Children.Add(new DictTreeDto
                    {
                        Id = item.Id,
                        Name = item.Label,
                        Type = "item",
                        Value = item.Value
                    });
                }

                tree.Add(typeNode);
            }

            return tree;
        }

        /// <summary>
        /// 添加字典项
        /// </summary>
        public async Task<long> AddAsync(long dictTypeId, string label, string value, int sort)
        {
            var item = new SysDictItem
            {
                Id = SnowFlakeSingle.instance.getID(),
                DictTypeId = dictTypeId,
                Label = label,
                Value = value,
                Sort = sort,
                CreatedTime = DateTime.Now
            };
            await _dictItemRepo.AddAsync(item);
            return item.Id;
        }

        /// <summary>
        /// 修改字典项
        /// </summary>
        public async Task<bool> UpdateAsync(long id, string label, string value, int sort)
        {
            var item = await _dictItemRepo.GetByIdAsync(id);
            if (item == null)
                return false;

            item.Label = label;
            item.Value = value;
            item.Sort = sort;
            item.UpdatedTime = DateTime.Now;
            return await _dictItemRepo.UpdateAsync(item);
        }

        /// <summary>
        /// 删除字典项
        /// </summary>
        public async Task<bool> DeleteAsync(long id)
        {
            return await _dictItemRepo.DeleteAsync(id);
        }


    }
}
