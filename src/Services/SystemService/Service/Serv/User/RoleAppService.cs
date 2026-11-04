using SharedKernel;
using SqlSugar;
using SystemService.Infra.Dtos.User;
using SystemService.Infra.Entities;
using SystemService.Infra.QueryDtos.User;
using SystemService.Infra.Repositories.Interface.User;
using SystemService.Service.Interface.User;

namespace SystemService.Service.Serv.User
{
    public class RoleAppService : IRoleAppService
    {
        private readonly ISysRoleRepository _roleRepo;

        public RoleAppService(ISysRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }

        /// <summary>
        /// 分页查询角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<PagedResult<SysRole>> GetListAsync(RoleQueryDto dto)
        {
            var list = await _roleRepo.GetPagedListAsync(dto);
            var total = await _roleRepo.GetCountAsync(dto);
            return new PagedResult<SysRole>
            {
                Items = list,
                Total = total,
                PageIndex = dto.PageIndex,
                PageSize = dto.PageSize
            };
        }

        /// <summary>
        /// 根据角色编号查询角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SysRole?> GetByIdAsync(long id)
        {
            return await _roleRepo.GetByIdAsync(id);
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<long> AddAsync(RoleCreateDto dto)
        {
            var existRole = await _roleRepo.GetByCodeAsync(dto.Code);
            if (existRole != null)
                throw new Exception("角色编码已存在");

            var role = new SysRole
            {
                Id = SnowFlakeSingle.instance.getID(),
                Code = dto.Code,
                Name = dto.Name,
                DataScope = dto.DataScope,
                Remark = dto.Remark,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            };

            await _roleRepo.AddAsync(role);
            return role.Id;
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAsync(long id, RoleCreateDto dto)
        {
            var role = await _roleRepo.GetByIdAsync(id);
            if (role == null)
                throw new Exception("角色不存在");

            role.Name = dto.Name;
            role.DataScope = dto.DataScope;
            role.Remark = dto.Remark;
            role.UpdatedTime = DateTime.Now;

            await _roleRepo.UpdateAsync(role);
        }

        /// <summary>
        /// 根据ID删除角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(long id)
        {
            var role = await _roleRepo.GetByIdAsync(id);
            if (role == null)
                throw new Exception("角色不存在");

            role.IsDeleted = true;
            role.UpdatedTime = DateTime.Now;
            await _roleRepo.UpdateAsync(role);
        }
    }
}
