using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    /// <summary>
    /// 返回体分页
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResult<T>
    {
        /// <summary>当前页数据</summary>
        public List<T> Items { get; set; } = [];

        /// <summary>总记录数</summary>
        public int Total { get; set; }

        /// <summary>当前页码（从 1 开始）</summary>
        public int PageIndex { get; set; }

        /// <summary>每页条数</summary>
        public int PageSize { get; set; }

        /// <summary>总页数</summary>
        public int TotalPages => PageSize <= 0 ? 0 : (Total + PageSize - 1) / PageSize;

        /// <summary>是否还有下一页（小程序上拉加载用）</summary>
        public bool HasNext => PageIndex < TotalPages;
    }
}
