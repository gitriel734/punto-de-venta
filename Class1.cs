using Dapper;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace PV.DAL
{
    public class DataAccess
    {

        #region Singleton
        private static volatile DataAccess instance = null;
        private static readonly object padlock = new object();
        public static string conString = "Server=GABRIEL\\SQLEXPRESS; Database=SimiDB; User Id=Blast; Password=1234554321;";

        private DataAccess() { }

        public static DataAccess Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new DataAccess();
            return instance;
        }

        #endregion

        #region Query/Execute Dapper

        public T QuerySingle<T>(String Query)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingle<T>(Query, commandType: CommandType.StoredProcedure, commandTimeout: 300);

        }

        public T QuerySingle<T>(String Query, DynamicParameters dynamicParmeters)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingle<T>(Query, dynamicParmeters, commandType: CommandType.StoredProcedure, commandTimeout: 300);

        }

        public T QuerySingleOrDefault<T>(String Query)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingleOrDefault<T>(Query, commandType: CommandType.StoredProcedure, commandTimeout: 300);

        }

        public T QuerySingleOrDefault<T>(String Query, DynamicParameters dynamicParameters)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingleOrDefault<T>(Query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 300);

        }

        public string QueryString(string query)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingle<string>(query, commandType: CommandType.StoredProcedure, commandTimeout: 300);
        }

        public string QueryString(string query, DynamicParameters dynamicParameters)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingle<string>(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 300);
        }

        public List<T> Query<T>(string query)
        {
            using (var con = new SqlConnection(conString))
                return con.Query<T>(query, commandType: CommandType.StoredProcedure, commandTimeout: 300).ToList();
        }

        public List<T> Query<T>(string query, DynamicParameters dynamicParameters)
        {
            using (var con = new SqlConnection(conString))
                return con.Query<T>(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 300).ToList();
        }

        public int Insert(string query, DynamicParameters dynamicParameters, string fieldName)
        {
            using (var con = new SqlConnection(conString))
                return (int)((IDictionary<string, object>)con.QuerySingle(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 300))[fieldName];
        }

        public int Execute(string query)
        {
            using (var con = new SqlConnection(conString))
                return con.Execute(query, commandType: CommandType.StoredProcedure, commandTimeout: 300);
        }

        public int Execute(string query, DynamicParameters dynamicParameters)
        {
            using (var con = new SqlConnection(conString))
                return con.Execute(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 300);
        }
        #endregion
    }
}
