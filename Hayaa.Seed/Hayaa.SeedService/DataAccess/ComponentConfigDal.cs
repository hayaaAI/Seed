using Hayaa.SeedService.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.ISeedService.Model;

namespace Hayaa.SeedService.DataAccess
{
    class ComponentConfigDal: CommonDal
    {      
        internal static int Add(ComponentConfigInfo info)
        {
            string sql = "insert ComponentConfig (ComponentConfigID,ComponentID,ConfigContent,Version,Title,Description,IsDelete,CreateBy,CreateTime,ModifyBy,ModifyTime,DeleteBy,DeleteTime) values(@ComponentConfigID,@ComponentID,@ConfigContent,@Version,@Title,@Description,@IsDelete,@CreateBy,@CreateTime,@ModifyBy,@ModifyTime,@DeleteBy,@DeleteTime)";
            return Update<ComponentConfigInfo>(sql, info) ;
        }
		  internal static int update(ComponentConfigInfo info)
        {
            string sql = "update ComponentConfig set ComponentConfigID=@ComponentConfigID,ComponentID=@ComponentID,ConfigContent=@ConfigContent,Version=@Version,Title=@Title,Description=@Description,IsDelete=@IsDelete,CreateBy=@CreateBy,CreateTime=@CreateTime,ModifyBy=@ModifyBy,ModifyTime=@ModifyTime,DeleteBy=@DeleteBy,DeleteTime=@DeleteTime where ComponentConfigID=@ComponentConfigID";
            return Update<ComponentConfigInfo>(sql, info) ;
        }
		 internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from ComponentConfig where AppID in(@ids)";
            return Excute(sql, new { ids = IDs.ToArray() })>0;
        }
		  internal static ComponentConfigInfo Get(int infoID)
        {
            string sql = "select * from ComponentConfig  where ComponentConfigID=@ComponentConfigID";
            return Get<ComponentConfigInfo>(sql, new{ ComponentConfigID=infoID}) ;
        }
		internal static List<ComponentConfigInfo> GetList()
        {
            string sql = "select * from ComponentConfig";
            return GetList<ComponentConfigInfo>(sql, null) ;
        }
		internal static GridPager<ComponentConfigInfo> GetGridPager(int pageSize,int pageIndex,string searcheKey)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from ComponentConfig where 1=1 limit (@pageIndex-1)*@pageSize,@pageIndex*@pageSize;select FOUND_ROWS();";
            return GetGridPager<ComponentConfigInfo>(sql,pageSize,pageIndex,new{pageSize=pageSize,pageIndex=pageIndex,searchKey=searcheKey}) ;
        }
    }
}
