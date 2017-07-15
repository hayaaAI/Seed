using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.SeedService.DataAccess
{
    class ComponentConfigDal: CommonDal
    {
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from ComponentConfig where ComponentConfigID in(@ids)";
            return Excute(sql, new { ids = IDs.ToArray() }) > 0;
        }
    }
}
