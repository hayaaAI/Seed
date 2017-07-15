using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hayaa.ProgrameSeed.Model.Config
{
    /// <summary>
    /// 种子服务配置
    /// </summary>
    [Serializable]
  internal  class SeedConfig
    {
        /// <summary>
        /// 种子服务地址
        /// </summary>
        public string SeedServerUrl { set; get; }       
        /// <summary>
        /// 本地模式下配置目录存储路径
        /// </summary>
        public  string LocalConfigDirectoryPath { set; get; }
        /// <summary>
        /// 存储路径是否相对路径目录
        /// </summary>
        public bool IsVirtualPath { set; get; }
        /// <summary>
        /// 配置侦听地址
        /// </summary>
        public string AppConfigSentinelUrl { set; get; }
        /// <summary>
        /// 传输密匙
        /// </summary>
        public string TransfersSecurityKey { get; set; }
        /// <summary>
        /// 承载服务程序ID
        /// </summary>
        public int AppID { set; get; }
        /// <summary>
        /// 程序配置方案ID
        /// </summary>
        public Guid AppConfigID
        {
            get;
            set;
        }
        /// <summary>
        /// 程序配置方案版本
        /// 0表示获取最新
        /// </summary>
        public int Version
        {
            get;
            set;
        }
        /// <summary>
        /// 配置模式是否远程化
        /// </summary>
        public virtual bool IsRemote
        {
            get;
            set;
        }
        /// <summary>
        /// 程序配置文件名
        /// </summary>
        public string AppConfigFileName { get; internal set; }
    }
}
