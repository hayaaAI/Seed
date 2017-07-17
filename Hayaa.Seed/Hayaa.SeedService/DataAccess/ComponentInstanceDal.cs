using Hayaa.SeedService.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.ISeedService.Model;

namespace Hayaa.SeedService.DataAccess
{
    class ComponentInstanceDal: CommonDal
    {      
        internal static int Add(ComponentInstanceInfo info)
        {
            string sql = "insert ComponentInstance  (ComponentInstanceID,ComponetID,ComponentServiceCompeleteName,ComponentServiceName,ComponentAssemblyName,ComponentAssemblyFileName,ComponentAssemblyFileStorePath,ComponentInterface,ServiceUrl,AssemblyVersion,Title,Description,IsDelete,CreateBy,CreateTime,ModifyBy,ModifyTime,DeleteBy,DeleteTime) values(@ComponentInstanceID,@ComponetID,@ComponentServiceCompeleteName,@ComponentServiceName,@ComponentAssemblyName,@ComponentAssemblyFileName,@ComponentAssemblyFileStorePath,@ComponentInterface,@ServiceUrl,@AssemblyVersion,@Title,@Description,@IsDelete,@CreateBy,@CreateTime,@ModifyBy,@ModifyTime,@DeleteBy,@DeleteTime)";
            return Update<ComponentInstanceInfo>(sql, info) ;
        }
		  internal static int update(ComponentInstanceInfo info)
        {
            string sql = "update ComponentInstance set ComponentInstanceID=@ComponentInstanceID,ComponetID=@ComponetID,ComponentServiceCompeleteName=@ComponentServiceCompeleteName,ComponentServiceName=@ComponentServiceName,ComponentAssemblyName=@ComponentAssemblyName,ComponentAssemblyFileName=@ComponentAssemblyFileName,ComponentAssemblyFileStorePath=@ComponentAssemblyFileStorePath,ComponentInterface=@ComponentInterface,ServiceUrl=@ServiceUrl,AssemblyVersion=@AssemblyVersion,Title=@Title,Description=@Description,IsDelete=@IsDelete,CreateBy=@CreateBy,CreateTime=@CreateTime,ModifyBy=@ModifyBy,ModifyTime=@ModifyTime,DeleteBy=@DeleteBy,DeleteTime=@DeleteTime where ComponentInstanceID=@ComponentInstanceID";
            return Update<ComponentInstanceInfo>(sql, info) ;
        }
		 internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from ComponentInstance where AppID in(@ids)";
            return Excute(sql, new { ids = IDs.ToArray() })>0;
        }
		  internal static ComponentInstanceInfo Get(int infoID)
        {
            string sql = "select * from ComponentInstance  where ComponentInstanceID=@ComponentInstanceID";
            return Get<ComponentInstanceInfo>(sql, new{ ComponentInstanceID=infoID}) ;
        }
		internal static List<ComponentInstanceInfo> GetList()
        {
            string sql = "select * from ComponentInstance";
            return GetList<ComponentInstanceInfo>(sql, null) ;
        }
		internal static GridPager<ComponentInstanceInfo> GetGridPager(int pageSize,int pageIndex,string searcheKey)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from ComponentInstance where 1=1 limit (@pageIndex-1)*@pageSize,@pageIndex*@pageSize;select FOUND_ROWS();";
            return GetGridPager<ComponentInstanceInfo>(sql,pageSize,pageIndex,new{pageSize=pageSize,pageIndex=pageIndex,searchKey=searcheKey}) ;
        }
    }
}
