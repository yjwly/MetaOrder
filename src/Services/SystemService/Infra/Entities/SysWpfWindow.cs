using SharedKernel;
using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// WPF窗口表
    /// </summary>
    [SugarTable("sys_wpf_window")]
    public class SysWpfWindow : TenantEntity
    {
        /// <summary>窗口编码</summary>
        [SugarColumn(ColumnName = "window_code")]
        public string WindowCode { get; set; } = "";

        /// <summary>窗口名称</summary>
        [SugarColumn(ColumnName = "window_name")]
        public string WindowName { get; set; } = "";
    }
}
