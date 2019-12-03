using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace SQLDB
{
  public static class SQLDB
    {
      
        private static string connectionString = "";
        public static string ConnectionString
        {
            get
            {
                return connectionString;
            }

            set
            {
                connectionString = value;
            }
        }
        public static SqlConnection getConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            return conn;

        }


        public static int ExcuteNonQuery(SqlCommand cmd)
        {
            if (cmd.Connection != null)
            {
              return  cmd.ExecuteNonQuery();
            }
            else
            {
                using (SqlConnection conn = getConnection())
                {
                    cmd.Connection = conn;
                 return   cmd.ExecuteNonQuery();
                }
            }
        }
        public static DataTable getData(SqlCommand cmd)
        {
            if (cmd.Connection != null)
            {
                using (DataSet ds = new DataSet())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
            else
            {
                using (SqlConnection conn = getConnection())
                {
                    using (DataSet ds = new DataSet())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            cmd.Connection = conn;
                            da.SelectCommand = cmd;
                            da.Fill(ds);
                            return ds.Tables[0];
                        }
                    }
                }
            }
        }
    }
}
