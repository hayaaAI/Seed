using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ISeedService.Model
{
    /// <summary>
    /// 分页数据容器
    /// </summary>
   public class GridPager<T>: Result
    {
        public List<T> Data { set; get; }
        public int PageSize { set; get; }
        public int PageIndex { set; get; }
    }
}
