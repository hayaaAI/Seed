using Hayaa.ProgrameSeed.Config;
using Hayaa.ProgrameSeed.Model;
using Hayaa.ProgrameSeed.Model.Config;
using Hayaa.ProgrameSeed.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hayaa.ProgrameSeed
{
    public class ProgramSeed
    {
        private static ProgramSeed _instance = new ProgramSeed();
        private ProgramInstanceEnvironment _ProgramInstanceEnvironment = new ProgramInstanceEnvironment();
        static ProgramSeed()
        {
            
        }
        public static ProgramSeed Instance
        {
            get
            {
                return _instance;
            }
        }
        private InstanceEnvironmentInfo _Environment;
        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <returns></returns>
        public string InitProgram()
        {
            string result = "";
            try
            {

                ///探测部署环境
                //操作系统、网络环境、部署类型、程序集信息
                _Environment = _ProgramInstanceEnvironment.ScanEnvironment();
                //支持分布式配置系统则获取配置
                ProgramDistributedConfig.Instance.RunInAppStartInit();
                var seedConfig = ProgramDistributedConfig.Instance.GetSeedConfig();
                ///发送基础环境信息
                SendbaseInfo(_Environment, seedConfig.SeedServerUrl);
                ///发送配置信息
                SendSeedConfigInfo(seedConfig, seedConfig.SeedServerUrl);
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }
        /// <summary>
        /// 重置配置
        /// </summary>
        /// <returns></returns>
        public string ResetConfig()
        {
            return InitProgram();
        }
        /// <summary>
        /// 发送配置信息
        /// </summary>
        /// <param name="appConfig"></param>
        /// <param name="seedServerUrl"></param>
        private void SendSeedConfigInfo(SeedConfig appConfig, string seedServerUrl)
        {
            Dictionary<string, string> paramters = new Dictionary<string, string>();
            string info = JsonConvert.SerializeObject(appConfig);
            paramters.Add(SeedDefineTable.UrlAction, SeedDefineTable.UrlAction_SendSeedConfig);
            paramters.Add(SeedDefineTable.AppConfig, info);
            paramters.Add(SeedDefineTable.SentinelSign, SecurityProvider.GetMd5Sign(info));
            var r = HttpRequestHelper.Instance.GetNormalRequestResult(seedServerUrl, paramters);
            // LoggerPool.Instance.DefaultLogger.Info("SendAppConfigInfo结果:{0}", r);
        }
        /// <summary>
        /// 发送环境信息
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="seedServerUrl"></param>
        private void SendbaseInfo(InstanceEnvironmentInfo environment, string seedServerUrl)
        {
            Dictionary<string, string> paramters = new Dictionary<string, string>();
            string info = JsonConvert.SerializeObject(environment);
            paramters.Add(SeedDefineTable.UrlAction, SeedDefineTable.UrlAction_SendEvn);
            paramters.Add(SeedDefineTable.Eveinfo, info);
            paramters.Add(SeedDefineTable.SentinelSign, SecurityProvider.GetMd5Sign(info));
            var r = HttpRequestHelper.Instance.GetNormalRequestResult(seedServerUrl, paramters);
            // LoggerPool.Instance.DefaultLogger.Info("SendAppConfigInfo结果:{0}", r);
        }
    }
}
