using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ISeedService.Model
{
    /// <summary>
    /// 程序配置信息
    /// </summary>
    [Serializable]
   public class AppConfigInfo : ClassRoot
    {
        public int AppConfigID { set; get; }
        /// <summary>
        /// 程序ID
        /// </summary>	
        public int AppID
        {
            get;
            set;
        }
        /// <summary>
        /// 解决方案ID
        /// </summary>	
        public Guid SolutionID
        {
            get;
            set;
        }        
        /// <summary>
        /// 方案配置
        /// </summary>	
        public string ConfigContent
        {
            get;
            set;
        }

        /// <summary>
        /// 程序配置方案版本 
        /// </summary>
        public int Version
        {
            get;
            set;
        }
       
    }
}
