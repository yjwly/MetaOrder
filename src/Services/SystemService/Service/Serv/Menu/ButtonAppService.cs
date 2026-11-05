using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface;
using SystemService.Infra.Repositories.Interface.Menu;
using SystemService.Service.Interface.Menu;

namespace SystemService.Service.Serv.Menu
{
    /// <summary>
    /// 按钮服务实现
    /// </summary>
    public class ButtonAppService : IButtonAppService
    {
        private readonly ISysUserRoleRepository _userRoleRepo;
        private readonly ISysButtonRepository _buttonRepo;

        public ButtonAppService(
            ISysUserRoleRepository userRoleRepo,
            ISysButtonRepository buttonRepo)
        {
            _userRoleRepo = userRoleRepo;
            _buttonRepo = buttonRepo;
        }

        /// <summary>
        ///根据用户ID查按钮编码列表
        /// </summary>
        public async Task<List<string>> GetButtonsByUserIdAsync(long userId)
        {
            // 查这个用户有哪些角色
            var roleIds = await _userRoleRepo.GetRoleIdsByUserIdAsync(userId);

            // 查这些角色有哪些按钮
            var buttons = await _buttonRepo.GetButtonsByRoleIdsAsync(roleIds);

            return buttons.Select(x => x.Code).Distinct().ToList();
        }

        /// <summary>
        ///根据菜单ID查按钮列表
        /// </summary>
        public async Task<List<SysButton>> GetListByMenuIdAsync(long menuId)
        {
            return await _buttonRepo.GetListByMenuIdAsync(menuId);
        }

        /// <summary>
        ///添加按钮
        /// </summary>
        public async Task<long> AddAsync(long menuId, string name, string code)
        {
            var button = new SysButton
            {
                Id = SnowFlakeSingle.instance.getID(),
                MenuId = menuId,
                Name = name,
                Code = code,
                CreatedTime = DateTime.Now
            };
            await _buttonRepo.AddAsync(button);
            return button.Id;
        }

        /// <summary>
        /// 修改按钮
        /// </summary>
        public async Task<bool> UpdateAsync(long id, string name, string code)
        {
            var button = await _buttonRepo.GetByIdAsync(id);
            if (button == null)
                return false;

            button.Name = name;
            button.Code = code;
            button.UpdatedTime = DateTime.Now;
            return await _buttonRepo.UpdateAsync(button);
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        public async Task<bool> DeleteAsync(long id)
        {
            return await _buttonRepo.DeleteAsync(id);
        }
    }
}
