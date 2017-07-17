using Hayaa.ProgrameSeed.Model.Config;
using Hayaa.SeedService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.SeedService.DataAccess
{
    class Rel_AppConfig_ComponentConfigDal : CommonDal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appConfigID"></param>
        /// <param name="componentInstanceIDs"><key,value>【组件配置ID，配置的版本】</param>
        /// <returns></returns>
        internal static int EditAppConfigComponents(int appConfigID, Dictionary<int, int> componentInstanceIDs)
        {
            StringBuilder sql = new StringBuilder();
            foreach(var kv in componentInstanceIDs)
            {
                sql.Append(string.Format("insert Rel_AppConfig_ComponentConfig(AppConfigID,ComponentConfigID,Version) values({0},{1},{2});", appConfigID,kv.Key,kv.Value));
            }
            return Excute(sql.ToString());
        }

        internal static Dictionary<int, int> GetAppConfigComponentsConfig(int appConfigID)
        {
            string sql = "select * from Rel_AppConfig_ComponentConfig where AppConfigID=@ID and IsDelete=0";
            var temp = GetList<Rel_AppConfig_ComponentConfig>(sql, new { ID = appConfigID });
            if (temp != null)
            {
                var dic = new Dictionary<int, int>();
                temp.ForEach(a => {
                    if (!dic.ContainsKey(a.ComponentConfigID))
                    {
                        dic.Add(a.ComponentConfigID, a.Version);
                    }
                });
                return dic;
            }
            return null;
        }
        internal static List<ComponentConfig> GetComponentsConfigList(int appConfigID)
        {
            string sql = "select cc.* from Rel_AppConfig_ComponentConfig r inner join ComponentConfig cc on r.ComponentConfigID=cc.ComponentConfig and r.Version=cc.Version where AppConfigID=@ID and IsDelete=0";
            return GetList<ComponentConfig>(sql, new { ID = appConfigID });
           
        }
    }
}
