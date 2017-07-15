using Hayaa.ProgrameSeed.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ISeedService.Model
{
    /// <summary>
    /// 程序部署实例
    /// </summary>
    public class AppInstanceInfo : ClassRoot
    {
        /// <summary>
        /// 程序ID
        /// </summary>
        public int AppID { set; get; }
        /// <summary>
        /// 程序部署实例ID
        /// </summary>
        public int AppInstanceID { set; get; }
        /// <summary>
        /// 部署信息
        /// </summary>
        public InstanceEnvironmentInfo InstanceInfo { set; get; }

    }
}
