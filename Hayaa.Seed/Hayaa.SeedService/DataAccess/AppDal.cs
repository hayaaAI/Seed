using Hayaa.SeedService.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.ISeedService.Model;

namespace Hayaa.SeedService.DataAccess
{
    class AppDal: CommonDal
    {
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from App where AppID in(@ids)";
            return Excute(sql, new { ids = IDs.ToArray() })>0;
        }

        internal static int Edit(AppInfo info)
        {
            string sql = "";
            return Update<AppInfo>(sql, info) ;
        }
    }
}
