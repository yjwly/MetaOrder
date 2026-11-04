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
    }
}
