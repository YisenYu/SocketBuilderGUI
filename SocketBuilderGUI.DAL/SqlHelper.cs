using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Data;
// reference: System.Configuration



/// NOTICE
/// Rebuild this sub-project when you modify it.
namespace EthanYuWPFKit.DAL
{
    public static class SqlHelper
    {
        private static string connection_str = ConfigurationManager.AppSettings["SQLite_connection_str"];


        static SqlHelper()
        {
        }


        public static int ExecuteNonQuery(string cmd, params SQLiteParameter[] sql_params)
        {
            using (SQLiteConnection sql_con = new SQLiteConnection(connection_str))
            {
                sql_con.Open();
                using (SQLiteCommand sql_cmd = sql_con.CreateCommand())
                {
                    sql_cmd.CommandText = cmd;
                    sql_cmd.Parameters.AddRange(sql_params);
                    return sql_cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string cmd, params SQLiteParameter[] sql_params)
        {
            using (SQLiteConnection sql_con = new SQLiteConnection(connection_str))
            {
                sql_con.Open();
                using (SQLiteCommand sql_cmd = sql_con.CreateCommand())
                {
                    sql_cmd.CommandText = cmd;
                    sql_cmd.Parameters.AddRange(sql_params);
                    return sql_cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable ExecuteDataTable(string cmd, params SQLiteParameter[] sql_params)
        {
            using (SQLiteConnection sql_con = new SQLiteConnection(connection_str))
            {
                sql_con.Open();
                using (SQLiteCommand sql_cmd = sql_con.CreateCommand())
                {
                    sql_cmd.CommandText = cmd;
                    sql_cmd.Parameters.AddRange(sql_params);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql_cmd);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);
                    return dataset.Tables[0];

                }
            }
        }

        public static object ToDbValue(object value)
        {
            if (value == null) { return DBNull.Value; }
            else { return value; }
        }
        public static object FromDbValue(object value)
        {
            if (value == DBNull.Value) { return null; }
            else { return value; }
        }

    }
}
