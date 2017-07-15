using Hayaa.SeedService.Util;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;

namespace Hayaa.SeedService.DataAccess
{
    class CommonDal
    {
        internal static int Update<T>(string sql,T data)
        {
            IDbConnection conn = new MySqlConnection(AppConfigHelper.GetCon());
            return conn.Execute(sql, data);
        }
        internal static int Excute(string sql, object parama)
        {
            IDbConnection conn = new MySqlConnection(AppConfigHelper.GetCon());
            return conn.Execute(sql, parama);
        }
    }
}
