using Hayaa.SeedService.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.ISeedService.Model;

namespace Hayaa.SeedService.DataAccess
{
    class AppDal: CommonDal
    {      
        internal static int Add(AppInfo info)
        {
            string sql = "insert App (AppID,AppName,Title,Description,IsDelete,CreateBy,CreateTime,ModifyBy,ModifyTime,DeleteBy,DeleteTime) values(@AppID,@AppName,@Title,@Description,@IsDelete,@CreateBy,@CreateTime,@ModifyBy,@ModifyTime,@DeleteBy,@DeleteTime)";
            return Update<AppInfo>(sql, info) ;
        }
		  internal static int update(AppInfo info)
        {
            string sql = "update App set AppID=@AppID,AppName=@AppName,Title=@Title,Description=@Description,IsDelete=@IsDelete,CreateBy=@CreateBy,CreateTime=@CreateTime,ModifyBy=@ModifyBy,ModifyTime=@ModifyTime,DeleteBy=@DeleteBy,DeleteTime=@DeleteTime where AppID=@AppID";
            return Update<AppInfo>(sql, info) ;
        }
		 internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from App where AppID in(@ids)";
            return Excute(sql, new { ids = IDs.ToArray() })>0;
        }
		  internal static AppInfo Get(int infoID)
        {
            string sql = "select * from App  where AppID=@AppID";
            return Get<AppInfo>(sql, new{ AppID=infoID}) ;
        }
		internal static List<AppInfo> GetList()
        {
            string sql = "select * from App";
            return GetList<AppInfo>(sql, null) ;
        }
		internal static GridPager<AppInfo> GetGridPager(int pageSize,int pageIndex,string searcheKey)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from App where 1=1 limit (@pageIndex-1)*@pageSize,@pageIndex*@pageSize;select FOUND_ROWS();";
            return GetGridPager<AppInfo>(sql,pageSize,pageIndex,new{pageSize=pageSize,pageIndex=pageIndex,searchKey=searcheKey}) ;
        }
    }
}
