using SystemService.Infra.Entities;

namespace SystemService.Service.Interface.Base
{
    /// <summary>
    /// 字典类型服务接口
    /// </summary>
    public interface IDictTypeAppService
    {
        /// <summary>
        /// 查询所有字典类型列表
        /// </summary>
        Task<List<SysDictType>> GetListAsync();

        /// <summary>
        /// 添加字典类型
        /// </summary>
        Task<long> AddAsync(string name, string code);

        /// <summary>
        /// 修改字典类型
        /// </summary>
        Task<bool> UpdateAsync(long id, string name, string code);

        /// <summary>
        /// 删除字典类型
        /// </summary>
        Task<bool> DeleteAsync(long id);

    }
}
