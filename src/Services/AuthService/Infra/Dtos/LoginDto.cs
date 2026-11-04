namespace AuthService.Infra.Dtos
{
    public class LoginDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = "";

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = "";

        /// <summary>设备类型：web/wpf/mp(小程序)</summary>
        public string DeviceType { get; set; } = "web";
    }
}
