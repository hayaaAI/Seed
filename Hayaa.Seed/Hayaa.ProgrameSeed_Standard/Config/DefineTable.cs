using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hayaa.ProgrameSeed.Config
{
    public class SeedDefineTable
    {
        public const string AppConfig = "appconfiginfo";
        public const string Eveinfo = "eveinfo";
        public const string GetRmoteConfigAction = "getconfig";
        public const string SentinelSign = "ssign";
        public const string SolutionIDParam = "sid";
        public const string UrlAction = "action";
        /// <summary>
        /// 发送环境动作
        /// </summary>
        public const string UrlAction_SendEvn = "sendevn";
        /// <summary>
        /// 发送种子配置动作
        /// </summary>
        public const string UrlAction_SendSeedConfig = "sendseedconfig";
    }
}
