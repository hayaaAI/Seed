using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hayaa.ProgrameSeed.Model.Config
{
    [Serializable]
   public class AppConfig
    {
        public bool IsFactory
        {
            get
            {
                return !((this.CompeontInstances == null) || (this.CompeontInstances.Count == 0));
            }

        }
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
        /// 解决方案名称
        /// </summary>	
         public string SolutionName
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
        /// <summary>
        /// 组件配置
        /// </summary>
        public List<ComponentConfig> Components { get; set; }
        /// <summary>
        /// 组件服务实例
        /// </summary>
       
        public List<ComponentService> CompeontInstances { get; set; }
    }
}
