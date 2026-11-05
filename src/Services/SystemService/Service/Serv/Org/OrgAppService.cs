using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Org;
using SystemService.Service.Interface.Org;

namespace SystemService.Service.Serv.Org
{
    /// <summary>
    /// 组织服务实现
    /// </summary>
    public class OrgAppService : IOrgAppService
    {
        private readonly ISysOrgRepository _orgRepo;

        public OrgAppService(ISysOrgRepository orgRepo)
        {
            _orgRepo = orgRepo;
        }

        /// <summary>
        /// 查询所有组织列表
        /// </summary>
        public async Task<List<SysOrg>> GetListAsync()
        {
            return await _orgRepo.GetListAsync();
        }

        /// <summary>
        /// 添加组织
        /// </summary>
        public async Task<long> AddAsync(string name, string code, long parentId, int sort)
        {
            var org = new SysOrg
            {
                Id = SnowFlakeSingle.instance.getID(),
                Name = name,
                Code = code,
                ParentId = parentId,
                Sort = sort,
                CreatedTime = DateTime.Now
            };
            await _orgRepo.AddAsync(org);
            return org.Id;
        }

        /// <summary>
        /// 修改组织
        /// </summary>
        public async Task<bool> UpdateAsync(long id, string name, string code, long parentId, int sort)
        {
            var org = await _orgRepo.GetByIdAsync(id);
            if (org == null)
                return false;

            org.Name = name;
            org.Code = code;
            org.ParentId = parentId;
            org.Sort = sort;
            org.UpdatedTime = DateTime.Now;
            return await _orgRepo.UpdateAsync(org);
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        public async Task<bool> DeleteAsync(long id)
        {
            return await _orgRepo.DeleteAsync(id);
        }
    }
}
