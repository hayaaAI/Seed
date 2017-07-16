using Hayaa.SeedService.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.ISeedService.Model;

namespace Hayaa.SeedService.DataAccess
{
    class ComponentDal: CommonDal
    {      
        internal static int Add(ComponentInfo info)
        {
            string sql = "insert (ComponentID,CompoentName,Title,Description,IsDelete,CreateBy,CreateTime,ModifyBy,ModifyTime,DeleteBy,DeleteTime) values(@ComponentID,@CompoentName,@Title,@Description,@IsDelete,@CreateBy,@CreateTime,@ModifyBy,@ModifyTime,@DeleteBy,@DeleteTime)";
            return Update<ComponentInfo>(sql, info) ;
        }
		  internal static int update(ComponentInfo info)
        {
            string sql = "update Component set ComponentID=@ComponentID,CompoentName=@CompoentName,Title=@Title,Description=@Description,IsDelete=@IsDelete,CreateBy=@CreateBy,CreateTime=@CreateTime,ModifyBy=@ModifyBy,ModifyTime=@ModifyTime,DeleteBy=@DeleteBy,DeleteTime=@DeleteTime where ComponentID=@ComponentID";
            return Update<ComponentInfo>(sql, info) ;
        }
		 internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from Component where AppID in(@ids)";
            return Excute(sql, new { ids = IDs.ToArray() })>0;
        }
		  internal static ComponentInfo Get(int infoID)
        {
            string sql = "select * from Component  where ComponentID=@ComponentID";
            return Get<ComponentInfo>(sql, new{ ComponentID=infoID}) ;
        }
		internal static List<ComponentInfo> GetList()
        {
            string sql = "select * from Component";
            return GetList<ComponentInfo>(sql, null) ;
        }
		internal static GridPager<ComponentInfo> GetGridPager(int pageSize,int pageIndex,string searcheKey)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from Component where 1=1 limit (@pageIndex-1)*@pageSize,@pageIndex*@pageSize;select FOUND_ROWS();";
            return GetGridPager<ComponentInfo>(sql,pageSize,pageIndex,new{pageSize=pageSize,pageIndex=pageIndex,searchKey=searcheKey}) ;
        }
    }
}
