using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    /// <summary>
    /// 查询分页
    /// </summary>
    public class PagedQuery
    {
        private int _pageIndex = 1;
        private int _pageSize = 20;

        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value < 1 ? 1 : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value is < 1 or > 200 ? 20 : value;   // 防刷
        }

        /// <summary>模糊搜索关键字</summary>
        public string? Keyword { get; set; }
    }
}
