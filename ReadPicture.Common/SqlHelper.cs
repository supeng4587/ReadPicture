using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ReadPicture.Common
{
    public class SqlHelper
    {
        private static readonly string _connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;



        /// <summary>
        /// 以DataTable的形式返回SqlServer的查询结果
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">参数数组param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable_connSQLServer(string cmdStr, params SqlParameter[] parameters)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmdStr, _connStr))
            {
                DataTable dt = new DataTable();
                if (parameters != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(parameters);
                }
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
