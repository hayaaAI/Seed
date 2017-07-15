using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ISeedService.Model
{
    /// <summary>
    /// 程序组件
    /// </summary>
   public class ComponentInfo:ClassRoot
    {
        /// <summary>
        /// 组件ID
        /// </summary>
        public int ComponentID { set; get; }
        /// <summary>
        /// 组建名称
        /// </summary>
        public string CompoentName { set; get; }
    }
}
