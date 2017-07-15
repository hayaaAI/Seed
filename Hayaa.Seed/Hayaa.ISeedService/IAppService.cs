using Hayaa.ISeedService.Model;
using Hayaa.ProgrameSeed.Model.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ISeedService
{
   public interface IAppService
    {
        /// <summary>
        /// 编辑程序基本信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        DataResult<int> EditApp(AppInfo info);
        /// <summary>
        /// 获取程序信息
        /// </summary>
        /// <param name="infoID"></param>
        /// <returns></returns>
        DataResult<AppInfo> GetApp(int infoID);
        /// <summary>
        /// 分页获取程序数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="searchName"></param>
        /// <returns></returns>
        GridPager<AppInfo> GetAppInfoPager(int pageSize,int pageIndex,string searchName);
        /// <summary>
        /// 批量删除程序
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        Result DeleteApp(List<int> IDs);
        /// <summary>
        /// 编辑程序配置基础信息
        /// </summary>
        DataResult<int> EditAppConfig(AppConfigInfo info);
        DataResult<AppConfigInfo> GetAppConfig(int appConfigID);
        /// <summary>
        /// 编辑程序组件配置信息关系
        /// </summary>
        /// <param name="appConfigID"></param>
        /// <param name="componentConfigIDs"><key,value>【组件配置ID，配置的版本】</param>
        /// <returns></returns>
        Result EditAppConfigComponents(int appConfigID, Dictionary<int, int> componentConfigIDs);
        DataResult<Dictionary<int, int>> GetAppConfigComponents(int appConfigID);
        /// <summary>
        /// 编辑程序组件实例与实例用户关系
        /// </summary>
        /// <param name="appConfigID"></param>
        /// <param name="componentInstanceIDs"><key,value>【组件实例ID，实例用户ID】</param>
        /// <returns></returns>
        Result EditAppConfigComponentInstances(int appConfigID, Dictionary<int,int> componentInstanceIDs);
        DataResult<Dictionary<int, int>> GetAppConfigComponentInstances(int appConfigID);
        /// <summary>
        /// 获取远程配置
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="appConfigID"></param>
        /// <param name="version">0表示获取当前程序的最新版本配置内容</param>
        /// <returns></returns>
        AppConfig GetRemoteAppConfig(int appID, Guid appConfigID,int version=0);
    }
}
