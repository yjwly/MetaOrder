using SystemService.Infra.Dtos.Base;
using SystemService.Infra.Entities;

namespace SystemService.Service.Interface.Base
{
    /// <summary>
    /// 字典项服务接口
    /// </summary>
    public interface IDictItemAppService
    {
        /// <summary>
        /// 根据字典类型ID查字典项列表
        /// </summary>
        Task<List<SysDictItem>> GetListByDictTypeIdAsync(long dictTypeId);
        /// <summary>
        /// 根据字典类型编码查字典项列表
        /// </summary>
        Task<List<SysDictItem>> GetListByDictTypeCodeAsync(string dictTypeCode);


        /// <summary>
        /// 生成字典树
        /// </summary>
        Task<List<DictTreeDto>> GetDictTreeAsync();


        /// <summary>
        /// 添加字典项
        /// </summary>
        Task<long> AddAsync(long dictTypeId, string label, string value, int sort);

        /// <summary>
        /// 修改字典项
        /// </summary>
        Task<bool> UpdateAsync(long id, string label, string value, int sort);

        /// <summary>
        /// 删除字典项
        /// </summary>
        Task<bool> DeleteAsync(long id);


    }
}
