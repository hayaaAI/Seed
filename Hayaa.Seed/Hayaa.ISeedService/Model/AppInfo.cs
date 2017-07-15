using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ISeedService.Model
{
    /// <summary>
    /// 应用程序
    /// </summary>
  public  class AppInfo: ClassRoot
    {
        /// <summary>
        /// 程序标识ID
        /// </summary>
        public int AppID { set; get; }
      
        /// <summary>
        /// 程序名称
        /// </summary>
        public string AppName { set; get; }
       
    }
}
