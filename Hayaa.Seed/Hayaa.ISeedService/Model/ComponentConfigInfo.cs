using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ISeedService.Model
{
    /// <summary>
    /// 组件配置信息
    /// </summary>
    [Serializable]
   public class ComponentConfigInfo:ClassRoot
    {
        /// <summary>
        /// 组件配置ID
        /// </summary>
        public int ComponentConfigID { set; get; }
        /// <summary>
        /// 组件ID
        /// </summary>
        public int ComponentID { set; get; }
        /// <summary>
        /// 组件配置内容
        /// </summary>
        public string ConfigContent { set; get; }
        /// <summary>
        /// 配置的版本号
        /// </summary>
        public int Version { set; get; }
    }
}
