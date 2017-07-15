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
                return !((this.Workers == null) || (this.Workers.Count == 0));
            }

        }
        /// <summary>
        /// 配置数据ID
        /// </summary>	
        public int ID
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
        public List<ComponentConfig> Components { get; set; }
       
        public List<ComponentService> Workers { get; set; }
    }
}
