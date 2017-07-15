using Hayaa.ISeedService;
using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.ISeedService.Model;
using Hayaa.ProgrameSeed.Model.Config;
using Hayaa.SeedService.DataAccess;

namespace Hayaa.SeedService
{
    public class SeedServer : IAppService, IComponetService
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
            int id = AppDal.Edit(info);
            return new DataResult<int>() { ActionResult = id>0, Data= id };
        }

        public DataResult<int> EditAppConfig(AppConfigInfo info)
        {
            throw new NotImplementedException();
        }

        public Result EditAppConfigComponentInstances(int appConfigID, Dictionary<int, int> componentInstanceIDs)
        {
            throw new NotImplementedException();
        }

        public Result EditAppConfigComponents(int appConfigID, Dictionary<int, int> componentConfigIDs)
        {
            throw new NotImplementedException();
        }

        public DataResult<int> EditComponent(ComponentInfo info)
        {
            throw new NotImplementedException();
        }

        public DataResult<int> EditComponentConfig(ComponentConfigInfo info)
        {
            throw new NotImplementedException();
        }

        public DataResult<int> EditComponentInstance(ComponentInstanceInfo info)
        {
            throw new NotImplementedException();
        }

        public DataResult<AppInfo> GetApp(int infoID)
        {
            throw new NotImplementedException();
        }

        public DataResult<AppConfigInfo> GetAppConfig(int appConfigID)
        {
            throw new NotImplementedException();
        }

        public DataResult<Dictionary<int, int>> GetAppConfigComponentInstances(int appConfigID)
        {
            throw new NotImplementedException();
        }

        public DataResult<Dictionary<int, int>> GetAppConfigComponents(int appConfigID)
        {
            throw new NotImplementedException();
        }

        public GridPager<AppInfo> GetAppInfoPager(int pageSize, int pageIndex, string searchName)
        {
            throw new NotImplementedException();
        }

        public DataResult<ComponentInfo> GetComponent(int infoID)
        {
            throw new NotImplementedException();
        }

        public DataResult<ComponentConfigInfo> GetComponentConfig(int infoID)
        {
            throw new NotImplementedException();
        }

        public GridPager<ComponentConfigInfo> GetComponentConfigPager(int pageSize, int pageIndex, int componentID, string searchName)
        {
            throw new NotImplementedException();
        }

        public GridPager<ComponentInfo> GetComponentInfoPager(int pageSize, int pageIndex, string searchName)
        {
            throw new NotImplementedException();
        }

        public DataResult<ComponentInstanceInfo> GetComponentInstance(int infoID)
        {
            throw new NotImplementedException();
        }

        public GridPager<ComponentInstanceInfo> GetComponentInstancePager(int pageSize, int pageIndex, int componentID, string searchName)
        {
            throw new NotImplementedException();
        }

        public AppConfig GetRemoteAppConfig(int appID, Guid appConfigID, int version = 0)
        {
            throw new NotImplementedException();
        }
    }
}
