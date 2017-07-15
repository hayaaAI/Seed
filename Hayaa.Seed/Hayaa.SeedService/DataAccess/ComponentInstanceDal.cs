using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.SeedService.DataAccess
{
    class ComponentInstanceDal : CommonDal
    {
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from ComponentInstance where ComponentInstanceID in(@ids)";
            return Excute(sql, new { ids = IDs.ToArray() }) > 0;
        }
    }
}
