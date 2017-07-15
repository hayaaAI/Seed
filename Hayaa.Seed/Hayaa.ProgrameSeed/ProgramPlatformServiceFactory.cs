using Hayaa.ProgrameSeed.Model.Config;
using Hayaa.ProgrameSeed.Util;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Description;
using System.Text;

namespace Hayaa.ProgrameSeed
{
    public class ProgramPlatformServiceFactory
    {
        /// <summary>
        /// 组建用户ID,【key：接口，value：接口实现类】
        /// </summary>
        private Dictionary<int, Dictionary<string, ComponentServiceInstance>> _serviceData;
        private ConcurrentDictionary<string, Assembly> _assembliesData;
        private static ProgramPlatformServiceFactory _instance = new ProgramPlatformServiceFactory();

        public static ProgramPlatformServiceFactory Instance
        {
            get { return _instance; }
        }
        private ProgramPlatformServiceFactory()
        {
            _assembliesData = new ConcurrentDictionary<string, Assembly>();
            _serviceData = new Dictionary<int, Dictionary<string, ComponentServiceInstance>>();
            InitData(ProgramDistributedConfig.Instance.GetComponentServices());

        }
        private void InitData(List<ComponentServiceInstance> appServiceConfigs)
        {
            if (appServiceConfigs != null)
            {
                var appUserIDs = appServiceConfigs.Select(a => a.AppUserID).Distinct().ToList();
                if (appUserIDs != null)
                {
                    appUserIDs.ForEach(a =>
                    {
                        if (!_serviceData.ContainsKey(a))
                        {
                            _serviceData.Add(a, new Dictionary<string, ComponentServiceInstance>());
                            var temp = appServiceConfigs.FindAll(b => b.AppUserID == a);
                            //一个实现类可能基于多个接口，此种模式对于基于一个接口实现了多个组件，并且组建用户相同情况不支持
                            temp.ForEach(c => {
                                c.ComponentInterface.ForEach(ci => {
                                    _serviceData[a].Add(ci, c);
                                });
                            });                            
                        }
                    });
                }
            }
        }
        public void Clear()
        {
            _serviceData.Clear();
            _assembliesData.Clear();
            ServiceFactory.Instance.Clear();
        }
        /// <summary>
        /// 创建服务实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="appUserID">程序用户ID</param>
        /// <returns></returns>
        public T CreateService<T>(int appUserID)
        {
            T tobj = default(T);
            tobj = ServiceFactory.Instance.GetService<T>(appUserID);
            if (tobj != null) return tobj;
            var key = typeof(T).FullName;
            if (_serviceData.Count == 0)
            {
                InitData(ProgramDistributedConfig.Instance.GetComponentServices());
            }
            if (_serviceData[appUserID].ContainsKey(key))
            {
                var serviceData = _serviceData[appUserID][key];
                string classkey = string.Format("{0}_{1}", appUserID, serviceData.ComponentServiceCompeleteName);
                if (serviceData.ComponentType == 2) return ServiceFactory.Instance.GetWcfService<T>(appUserID, serviceData.ServiceUrl);
                if (!_assembliesData.ContainsKey(classkey))
                {
                    if (!string.IsNullOrEmpty(serviceData.ComponentAssemblyFileStorePath))
                    {
                        if (serviceData.ComponentAssemblyFileStorePath.StartsWith(@"~"))
                            serviceData.ComponentAssemblyFileStorePath = System.Web.HttpContext.Current.Server.MapPath(serviceData.ComponentAssemblyFileStorePath);
                        if (!serviceData.ComponentAssemblyFileStorePath.EndsWith(@"\")) serviceData.ComponentAssemblyFileStorePath = serviceData.ComponentAssemblyFileStorePath + "\\";
                        _assembliesData.TryAdd(classkey, Assembly.LoadFrom(serviceData.ComponentAssemblyFileStorePath + serviceData.ComponentAssemblyFileName));
                    }
                }
                if (!string.IsNullOrEmpty(serviceData.ComponentAssemblyFileStorePath))
                    tobj = ServiceFactory.Instance.GetService<T>(appUserID, serviceData.ComponentServiceName, _assembliesData[classkey]);
                else
                    tobj = ServiceFactory.Instance.GetService<T>(appUserID, serviceData.ComponentServiceCompeleteName);
            }
            return tobj;
        }
        /// <summary>
        /// dll程序集测试
        /// </summary>
        /// <param name="appUserID"></param>
        /// <param name="interfaceName"></param>
        /// <returns></returns>
        internal Object CreateServiceForTest(int appUserID, string interfaceName)
        {
            Object tobj = null;
            tobj = ServiceFactory.Instance.GetServiceForTest(appUserID, interfaceName);
            if (tobj != null) return tobj;
            var key = interfaceName;
            if (_serviceData.Count == 0)
            {
                InitData(ProgramDistributedConfig.Instance.GetComponentServices());
            }
            if (_serviceData[appUserID].ContainsKey(key))
            {
                var serviceData = _serviceData[appUserID][key];
                string classkey = string.Format("{0}_{1}", appUserID, serviceData.ComponentServiceCompeleteName);
                if (!_assembliesData.ContainsKey(classkey))
                {
                    if (!string.IsNullOrEmpty(serviceData.ComponentAssemblyFileStorePath))
                    {
                        if (serviceData.ComponentAssemblyFileStorePath.StartsWith(@"~"))
                            serviceData.ComponentAssemblyFileStorePath = System.Web.HttpContext.Current.Server.MapPath(serviceData.ComponentAssemblyFileStorePath);
                        if (!serviceData.ComponentAssemblyFileStorePath.EndsWith(@"\")) serviceData.ComponentAssemblyFileStorePath = serviceData.ComponentAssemblyFileStorePath + "\\";
                        _assembliesData.TryAdd(classkey, Assembly.LoadFrom(serviceData.ComponentAssemblyFileStorePath + serviceData.ComponentAssemblyFileName));
                    }
                }
                if (!string.IsNullOrEmpty(serviceData.ComponentAssemblyFileStorePath))
                    tobj = ServiceFactory.Instance.GetServiceForTest(appUserID, serviceData.ComponentServiceName, _assembliesData[classkey], interfaceName);
                else
                    tobj = ServiceFactory.Instance.GetServiceForTest(appUserID, serviceData.ComponentServiceCompeleteName, interfaceName);
            }
            return tobj;
        }
    }
}
