using Hayaa.SeedService.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.ISeedService.Model;

namespace Hayaa.SeedService.DataAccess
{
    class AppConfigDal: CommonDal
    {      
        internal static int Add(AppConfigInfo info)
        {
            string sql = "insert AppConfig (AppConfigID,AppID,SolutionID,ConfigContent,Version,Title,Description,IsDelete,CreateBy,CreateTime,ModifyBy,ModifyTime,DeleteBy,DeleteTime) values(@AppConfigID,@AppID,@SolutionID,@ConfigContent,@Version,@Title,@Description,@IsDelete,@CreateBy,@CreateTime,@ModifyBy,@ModifyTime,@DeleteBy,@DeleteTime)";
            return Update<AppConfigInfo>(sql, info) ;
        }
		  internal static int update(AppConfigInfo info)
        {
            string sql = "update AppConfig set AppConfigID=@AppConfigID,AppID=@AppID,SolutionID=@SolutionID,ConfigContent=@ConfigContent,Version=@Version,Title=@Title,Description=@Description,IsDelete=@IsDelete,CreateBy=@CreateBy,CreateTime=@CreateTime,ModifyBy=@ModifyBy,ModifyTime=@ModifyTime,DeleteBy=@DeleteBy,DeleteTime=@DeleteTime where AppConfigID=@AppConfigID";
            return Update<AppConfigInfo>(sql, info) ;
        }
		 internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from AppConfig where AppID in(@ids)";
            return Excute(sql, new { ids = IDs.ToArray() })>0;
        }
		  internal static AppConfigInfo Get(int infoID)
        {
            string sql = "select * from AppConfig  where AppConfigID=@AppConfigID";
            return Get<AppConfigInfo>(sql, new{ AppConfigID=infoID}) ;
        }
		internal static List<AppConfigInfo> GetList()
        {
            string sql = "select * from AppConfig";
            return GetList<AppConfigInfo>(sql, null) ;
        }
		internal static GridPager<AppConfigInfo> GetGridPager(int pageSize,int pageIndex,string searcheKey)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from AppConfig where 1=1 limit (@pageIndex-1)*@pageSize,@pageIndex*@pageSize;select FOUND_ROWS();";
            return GetGridPager<AppConfigInfo>(sql,pageSize,pageIndex,new{pageSize=pageSize,pageIndex=pageIndex,searchKey=searcheKey}) ;
        }
        /// <summary>
        /// 获取有效的AppConfig数据
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="appConfigID"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        internal static AppConfigInfo Get(int appID, Guid appConfigID, int version)
        {
            string sql = "select * from AppConfig  where AppID=@AppID and SolutionID=@AppConfigID and Version=@Version and IsDelete=0";
            return Get<AppConfigInfo>(sql, new { AppID=appID,AppConfigID = appConfigID,Version=version });
        }
    }
}
