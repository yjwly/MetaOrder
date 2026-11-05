using SystemService.Infra.Dtos.Base;
using SystemService.Infra.Dtos.User;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface;
using SystemService.Infra.Repositories.Interface.User;
using SystemService.Service.Interface.User;

namespace SystemService.Service.Serv.User
{
    /// <summary>
    /// 用户角色服务实现
    /// </summary>
    public class UserRoleAppService : IUserRoleAppService
    {
        private readonly ISysUserRoleRepository _userRoleRepo;
        private readonly ISysUserRepository _userRepo;
        private readonly ISysRoleRepository _roleRepo;

        public UserRoleAppService(ISysUserRoleRepository userRoleRepo,ISysUserRepository userRepo,
        ISysRoleRepository roleRepo)
        {
            _userRoleRepo = userRoleRepo;
            _userRepo= userRepo;
            _roleRepo= roleRepo;
        }

        /// <summary>
        /// 根据用户ID查角色ID列表
        /// </summary>
        public async Task<List<long>> GetRoleIdsByUserIdAsync(long userId)
        {
            return await _userRoleRepo.GetRoleIdsByUserIdAsync(userId);
        }

        /// <summary>
        /// 分配角色
        /// </summary>
        public async Task AssignRolesAsync(UserRoleDto dto)
        {
            // 先删除旧的
            await _userRoleRepo.DeleteByUserIdAsync(dto.UserId);

            // 再添加新的
            var list = dto.RoleIds.Select(roleId => new SysUserRole
            {
                UserId = dto.UserId,
                RoleId = roleId
            }).ToList();

            if (list.Any())
            {
                await _userRoleRepo.AddRangeAsync(list);
            }
        }

        /// <summary>
        /// 获取用户角色树形结构
        /// </summary>
        public async Task<List<TreeNodeDto>> GetUserRoleTreeAsync()
        {
            // 查所有角色
            var roles = await _roleRepo.GetListAsync(x => true);

            // 查所有用户
            var users = await _userRepo.GetListAsync(x => true);

            var tree = new List<TreeNodeDto>();

            // 角色节点
            foreach (var role in roles)
            {
                var roleNode = new TreeNodeDto
                {
                    Id = role.Id,
                    Name = role.Name,
                    Type = "role"
                };

                // 查这个角色下的用户
                var userIds = await _userRoleRepo.GetRoleIdsByUserIdAsync(role.Id);

                foreach (var userId in userIds)
                {
                    var user = users.FirstOrDefault(x => x.Id == userId);
                    if (user != null)
                    {
                        roleNode.Children.Add(new TreeNodeDto
                        {
                            Id = user.Id,
                            Name = user.RealName,
                            Type = "user"
                        });
                    }
                }

                tree.Add(roleNode);
            }

            return tree;
        }

    }
}
