using Hayaa.ISeedService.Model;
using Hayaa.SeedService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.SeedService.DataAccess
{
    class Rel_AppConfig_ComponentInstanceDal : CommonDal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appConfigID"></param>
        /// <param name="componentInstanceIDs"><key,value>【组件实例ID，实例用户ID】</param>
        /// <returns></returns>
        internal static int EditAppConfigComponentInstances(int appConfigID, Dictionary<int, int> componentInstanceIDs)
        {
            StringBuilder sql = new StringBuilder();
            foreach(var kv in componentInstanceIDs)
            {
                sql.Append(string.Format("insert Rel_AppConfig_ComponentInstance (AppConfigID,ComponentInstanceID,AppUserID) values({0},{1},{2});", appConfigID,kv.Key,kv.Value));
            }
            return Excute(sql.ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appConfigID"></param>
        /// <returns><key,value>【组件实例ID，实例用户ID】</returns>
        internal static Dictionary<int, int> GetAppConfigComponentInstances(int appConfigID)
        {
            string sql = "select * from Rel_AppConfig_ComponentInstance where AppConfigID=@ID and IsDelete=0";
            var temp = GetList<Rel_AppConfig_ComponentInstance>(sql, new { ID = appConfigID });
            if (temp != null)
            {
                var dic = new Dictionary<int, int>();
                temp.ForEach(a => {
                    if (!dic.ContainsKey(a.ComponentInstanceID)) {
                        dic.Add(a.ComponentInstanceID, a.AppUserID);
                    }
                });
                return dic;
            }
            return null;
        }
        internal static List<ProgrameSeed.Model.Config.ComponentService> GetComponentInstanceList(int appConfigID)
        {
            string sql = "select ci.*,r.AppUserID from Rel_AppConfig_ComponentInstance r inner join ComponentInstance ci on r.ComponentInstanceID=ci.ComponentInstanceID where AppConfigID=@ID and IsDelete=0";
            return GetList<ProgrameSeed.Model.Config.ComponentService>(sql, new { ID = appConfigID });
           
        }
    }
}
