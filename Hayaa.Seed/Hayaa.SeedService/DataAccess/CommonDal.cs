using Hayaa.SeedService.Util;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;
using System.Collections.Generic;
using Hayaa.ISeedService.Model;

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
        internal static List<T> GetList<T>(string sql, object parama)
        {
            IDbConnection conn = new MySqlConnection(AppConfigHelper.GetCon());
            return conn.Query<T>(sql, parama).AsList<T>();
        }
        internal static T Get<T>(string sql, object parama)
        {
            IDbConnection conn = new MySqlConnection(AppConfigHelper.GetCon());
            return conn.QuerySingle<T>(sql, parama);
        }
        internal static GridPager<T> GetGridPager<T>(string sql,int pageSize,int pageIndex, object parama)
        {
            GridPager<T> r = new GridPager<T>() { PageIndex=pageIndex, PageSize=pageSize, ActionResult=false };
            IDbConnection conn = new MySqlConnection(AppConfigHelper.GetCon());
           var multi=conn.QueryMultiple(sql, parama);
            if (!multi.IsConsumed)
            {               
                r.Data = multi.Read<T>().AsList<T>();
                r.Total = multi.ReadSingle();
                if (r.Total > 0) r.ActionResult = true;
            }
            return r;
        }
    }
}
