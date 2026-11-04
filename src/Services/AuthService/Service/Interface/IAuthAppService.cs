using AuthService.Infra.Dtos;

namespace AuthService.Service.Interface
{
    public interface IAuthAppService
    {
        /// <summary>登录</summary>
        Task<(string accessToken, string refreshToken)> LoginAsync(LoginDto dto);

        /// <summary>刷新Token</summary>
        Task<(string accessToken, string refreshToken)> RefreshAsync(string deviceType, string refreshToken);

        /// <summary>退出登录</summary>
        Task LogoutAsync(string deviceType, string refreshToken);
    }
}
