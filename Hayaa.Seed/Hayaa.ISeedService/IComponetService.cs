using Hayaa.ISeedService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ISeedService
{
   public interface IComponetService
    {
        /// <summary>
        /// 编辑组件基本信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        DataResult<int> EditComponent(ComponentInfo info);
        DataResult<ComponentInfo> GetComponent(int infoID);
        /// <summary>
        /// 分页获取组件数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="searchName"></param>
        /// <returns></returns>
        GridPager<ComponentInfo> GetComponentInfoPager(int pageSize, int pageIndex, string searchName);
        /// <summary>
        /// 批量删除组件
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        Result DeleteComponent(List<int> IDs);
        DataResult<int> EditComponentConfig(ComponentConfigInfo info);
        DataResult<ComponentConfigInfo> GetComponentConfig(int infoID);
        GridPager<ComponentConfigInfo> GetComponentConfigPager(int pageSize, int pageIndex,int componentID, string searchName);
        Result DeleteComponentConfig(List<int> IDs);
        DataResult<int> EditComponentInstance(ComponentInstanceInfo info);
        DataResult<ComponentInstanceInfo> GetComponentInstance(int infoID);
        GridPager<ComponentInstanceInfo> GetComponentInstancePager(int pageSize, int pageIndex, int componentID, string searchName);
        Result DeleteComponentInstance(List<int> IDs);
    }
}
