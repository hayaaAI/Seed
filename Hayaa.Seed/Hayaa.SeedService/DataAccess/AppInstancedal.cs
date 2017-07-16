using Hayaa.SeedService.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.ISeedService.Model;

namespace Hayaa.SeedService.DataAccess
{
    class AppInstanceDal: CommonDal
    {      
        internal static int Add(AppInstanceInfo info)
        {
            string sql = "insert (AppInstanceID,AppID,InstanceInfo,Title,Description,IsDelete,CreateBy,CreateTime,ModifyBy,ModifyTime,DeleteBy,DeleteTime) values(@AppInstanceID,@AppID,@InstanceInfo,@Title,@Description,@IsDelete,@CreateBy,@CreateTime,@ModifyBy,@ModifyTime,@DeleteBy,@DeleteTime)";
            return Update<AppInstanceInfo>(sql, info) ;
        }
		  internal static int update(AppInstanceInfo info)
        {
            string sql = "update AppInstance set AppInstanceID=@AppInstanceID,AppID=@AppID,InstanceInfo=@InstanceInfo,Title=@Title,Description=@Description,IsDelete=@IsDelete,CreateBy=@CreateBy,CreateTime=@CreateTime,ModifyBy=@ModifyBy,ModifyTime=@ModifyTime,DeleteBy=@DeleteBy,DeleteTime=@DeleteTime where AppInstanceID=@AppInstanceID";
            return Update<AppInstanceInfo>(sql, info) ;
        }
		 internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from AppInstance where AppID in(@ids)";
            return Excute(sql, new { ids = IDs.ToArray() })>0;
        }
		  internal static AppInstanceInfo Get(int infoID)
        {
            string sql = "select * from AppInstance  where AppInstanceID=@AppInstanceID";
            return Get<AppInstanceInfo>(sql, new{ AppInstanceID=infoID}) ;
        }
		internal static List<AppInstanceInfo> GetList()
        {
            string sql = "select * from AppInstance";
            return GetList<AppInstanceInfo>(sql, null) ;
        }
		internal static GridPager<AppInstanceInfo> GetGridPager(int pageSize,int pageIndex,string searcheKey)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from AppInstance where 1=1 limit (@pageIndex-1)*@pageSize,@pageIndex*@pageSize;select FOUND_ROWS();";
            return GetGridPager<AppInstanceInfo>(sql,pageSize,pageIndex,new{pageSize=pageSize,pageIndex=pageIndex,searchKey=searcheKey}) ;
        }
    }
}
