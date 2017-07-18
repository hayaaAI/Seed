using Hayaa.ISeedService;
using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.ISeedService.Model;
using Hayaa.ProgrameSeed.Model.Config;
using Hayaa.SeedService.DataAccess;

namespace Hayaa.SeedService
{
    public partial class SeedServer :  IComponetService
    {
      

      
       

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
       
    }
}
