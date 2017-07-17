using Hayaa.ISeedService;
using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.ISeedService.Model;
using Hayaa.ProgrameSeed.Model.Config;
using Hayaa.SeedService.DataAccess;

namespace Hayaa.SeedService
{
    public partial class SeedServer : IAppService, IComponetService
    {
        public Result DeleteApp(List<int> IDs)
        {
            return new Result() { ActionResult = AppDal.Delete(IDs) };
        }

        public Result DeleteComponent(List<int> IDs)
        {
            return new Result() { ActionResult = ComponentDal.Delete(IDs) };
        }

        public Result DeleteComponentConfig(List<int> IDs)
        {
            return new Result() { ActionResult = ComponentConfigDal.Delete(IDs) };
        }

        public Result DeleteComponentInstance(List<int> IDs)
        {
            return new Result() { ActionResult = ComponentInstanceDal.Delete(IDs) };
        }

        public DataResult<int> EditApp(AppInfo info)
        {
            int id = 0;
            if (info.AppID == 0) id = AppDal.Add(info);
            else { id=AppDal.update(info); if (id > 0) id = info.AppID; }
            return new DataResult<int>() { ActionResult = id>0, Data= id };
        }

        public DataResult<int> EditAppConfig(AppConfigInfo info)
        {
            int id = 0;
            if (info.AppID == 0) id = AppConfigDal.Add(info);
            else { id = AppConfigDal.update(info); if (id > 0) id = info.AppID; }
            return new DataResult<int>() { ActionResult = id > 0, Data = id };
        }
        /// <summary>
        /// 编辑程序组件实例与实例用户关系
        /// </summary>
        /// <param name="appConfigID"></param>
        /// <param name="componentInstanceIDs"><key,value>【组件实例ID，实例用户ID】</param>
        /// <returns></returns>
        public Result EditAppConfigComponentInstances(int appConfigID, Dictionary<int, int> componentInstanceIDs)
        {
            return new Result() { ActionResult= Rel_AppConfig_ComponentInstanceDal.EditAppConfigComponentInstances(appConfigID, componentInstanceIDs)>0 };
        }
        /// <summary>
        /// 编辑程序组件配置信息关系
        /// </summary>
        /// <param name="appConfigID"></param>
        /// <param name="componentConfigIDs"><key,value>【组件配置ID，配置的版本】</param>
        public Result EditAppConfigComponents(int appConfigID, Dictionary<int, int> componentConfigIDs)
        {
            return new Result() { ActionResult = Rel_AppConfig_ComponentConfigDal.EditAppConfigComponents(appConfigID, componentConfigIDs) > 0 };
        }

        public DataResult<int> EditComponent(ComponentInfo info)
        {
            int id = 0;
            if (info.ComponentID == 0) id = ComponentDal.Add(info);
            else { id = ComponentDal.update(info); if (id > 0) id = info.ComponentID; }
            return new DataResult<int>() { ActionResult = id > 0, Data = id };
        }

        public DataResult<int> EditComponentConfig(ComponentConfigInfo info)
        {
            int id = 0;
            if (info.ComponentConfigID == 0) id = ComponentConfigDal.Add(info);
            else { id = ComponentConfigDal.update(info); if (id > 0) id = info.ComponentConfigID; }
            return new DataResult<int>() { ActionResult = id > 0, Data = id };
        }

        public DataResult<int> EditComponentInstance(ComponentInstanceInfo info)
        {
            int id = 0;
            if (info.ComponentInstanceID == 0) id = ComponentInstanceDal.Add(info);
            else { id = ComponentInstanceDal.update(info); if (id > 0) id = info.ComponentInstanceID; }
            return new DataResult<int>() { ActionResult = id > 0, Data = id };
        }

        public DataResult<AppInfo> GetApp(int infoID)
        {
            var temp = AppDal.Get(infoID);
            return new DataResult<AppInfo>() { ActionResult =(temp!=null), Data = temp };
        }

        public DataResult<AppConfigInfo> GetAppConfig(int appConfigID)
        {
            var temp = AppConfigDal.Get(appConfigID);
            return new DataResult<AppConfigInfo>() { ActionResult = (temp != null), Data = temp };
        }
        /// <summary>
        /// 获取程序的组件实例与程序用户关系
        /// </summary>
        /// <param name="appConfigID"></param>
        /// <returns><key,value>【组件实例ID，实例用户ID】</returns>
        public DataResult<Dictionary<int, int>> GetAppConfigComponentInstances(int appConfigID)
        {
            Dictionary<int, int> temp = Rel_AppConfig_ComponentInstanceDal.GetAppConfigComponentInstances(appConfigID);
            return new DataResult<Dictionary<int, int>>() { ActionResult = (temp != null), Data = temp };
        }
        /// <summary>
        /// 获取程序的组件的配置集合
        /// </summary>
        /// <param name="appConfigID"></param>
        /// <returns><key,value>【组件配置ID，配置的版本】</returns>
        public DataResult<Dictionary<int, int>> GetAppConfigComponentsConfig(int appConfigID)
        {
            Dictionary<int, int> temp = Rel_AppConfig_ComponentConfigDal.GetAppConfigComponentsConfig(appConfigID);
            return new DataResult<Dictionary<int, int>>() { ActionResult = (temp != null), Data = temp };
        }

        public GridPager<AppInfo> GetAppInfoPager(int pageSize, int pageIndex, string searchName)
        {
            return AppDal.GetGridPager(pageSize, pageIndex, searchName);
        }

        public DataResult<ComponentInfo> GetComponent(int componentID)
        {
            var temp = ComponentDal.Get(componentID);
            return new DataResult<ComponentInfo>() { ActionResult = (temp != null), Data = temp };
            
        }

        public DataResult<ComponentConfigInfo> GetComponentConfig(int componentConfigID)
        {
            var temp = ComponentConfigDal.Get(componentConfigID);
            return new DataResult<ComponentConfigInfo>() { ActionResult = (temp != null), Data = temp };
        }

        public GridPager<ComponentConfigInfo> GetComponentConfigPager(int pageSize, int pageIndex, int componentID, string searchName)
        {
            return ComponentConfigDal.GetGridPager(pageSize, pageIndex, searchName);
        }

        public GridPager<ComponentInfo> GetComponentInfoPager(int pageSize, int pageIndex, string searchName)
        {
            return ComponentDal.GetGridPager(pageSize, pageIndex, searchName);
        }

        public DataResult<ComponentInstanceInfo> GetComponentInstance(int componentInstanceID)
        {
            var temp = ComponentInstanceDal.Get(componentInstanceID);
            return new DataResult<ComponentInstanceInfo>() { ActionResult = (temp != null), Data = temp };
        }

        public GridPager<ComponentInstanceInfo> GetComponentInstancePager(int pageSize, int pageIndex, int componentID, string searchName)
        {
            return ComponentInstanceDal.GetGridPager(pageSize, pageIndex, searchName);
        }

        public AppConfig GetRemoteAppConfig(int appID, Guid appConfigID, int version = 0)
        {
            var appConfig = AppConfigDal.Get(appID, appConfigID, version);
            if (appConfig == null) return null;           
            List<ComponentConfig> compoentConfigList = Rel_AppConfig_ComponentConfigDal.GetComponentsConfigList(appConfig.AppConfigID);
            if (compoentConfigList==null) return null;
            List<ComponentService> componentInstanceInfoList = Rel_AppConfig_ComponentInstanceDal.GetComponentInstanceList(appConfig.AppConfigID);
            AppConfig r = new AppConfig() { Components = compoentConfigList, Workers = componentInstanceInfoList, ConfigContent = appConfig.ConfigContent, ID = appConfig.AppConfigID, SolutionID = appConfig.SolutionID, SolutionName = appConfig.Title, Version = appConfig.Version  };      
            return r;
        }
    }
}
