using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;
namespace EthanYuWPFKit.DAL
{
    static class SqlHelper
    {
        private static string connection_str = 
            ConfigurationManager.ConnectionStrings["db_connection_str"].ConnectionString;

        //public static int ExecuteNonQuery(string cmd) 
        //{
        //    using (SqlConnection sql_con = new SqlConnection(connection_str))
        //    {
        //        sql_con.Open();
        //        using(SqlCommand sql_cmd = sql_con.CreateCommand())
        //        {
        //            sql_cmd.CommandText = cmd;
        //            return sql_cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public static object ExecuteScalar(string cmd)
        //{
        //    using (SqlConnection sql_con = new SqlConnection())
        //    {
        //        sql_con.Open();
        //        using (SqlCommand sql_cmd = sql_con.CreateCommand())
        //        {
        //            sql_cmd.CommandText = cmd;
        //            return sql_cmd.ExecuteScalar();
        //        }
        //    }
        //}

        //public static DataSet ExecuteDataSet(string cmd)
        //{
        //    using (SqlConnection sql_con = new SqlConnection())
        //    {
        //        sql_con.Open();
        //        using (SqlCommand sql_cmd = sql_con.CreateCommand())
        //        {
        //            sql_cmd.CommandText = cmd;
        //            SqlDataAdapter adapter = new SqlDataAdapter(sql_cmd);
        //            DataSet dataset = new DataSet();
        //            adapter.Fill(dataset);
        //            return dataset;

        //        }
        //    }
        //}

        //public static DataTable ExecuteDataTable(string cmd)
        //{
        //    using (SqlConnection sql_con = new SqlConnection())
        //    {
        //        sql_con.Open();
        //        using (SqlCommand sql_cmd = sql_con.CreateCommand())
        //        {
        //            sql_cmd.CommandText = cmd;
        //            SqlDataAdapter adapter = new SqlDataAdapter(sql_cmd);
        //            DataSet dataset = new DataSet();
        //            adapter.Fill(dataset);
        //            return dataset.Tables[0];

        //        }
        //    }
        //}


        ///// <summary>
        ///// with SqlParameter[] sql_params
        ///// </summary>
        //public static int ExecuteNonQuery(string cmd, SqlParameter[] sql_params)
        //{
        //    using (SqlConnection sql_con = new SqlConnection(connection_str))
        //    {
        //        sql_con.Open();
        //        using (SqlCommand sql_cmd = sql_con.CreateCommand())
        //        {
        //            sql_cmd.CommandText = cmd;
        //            //foreach(SqlParameter param in sql_params)
        //            //{
        //            //    sql_cmd.Parameters.Add(param);
        //            //}
        //            sql_cmd.Parameters.AddRange(sql_params);
        //            return sql_cmd.ExecuteNonQuery();
        //        }
        //    }
        //}


        //public static object ExecuteScalar(string cmd, SqlParameter[] sql_params)
        //{
        //    using(SqlConnection sql_con = new SqlConnection())
        //    {
        //        sql_con.Open();
        //        using(SqlCommand sql_cmd = sql_con.CreateCommand())
        //        {
        //            sql_cmd.CommandText = cmd;
        //            sql_cmd.Parameters.AddRange(sql_params);
        //            return sql_cmd.ExecuteScalar();
        //        }
        //    }
        //}

        //public static DataTable ExecuteDataTable(string cmd, SqlParameter[] sql_params)
        //{
        //    using (SqlConnection sql_con = new SqlConnection())
        //    {
        //        sql_con.Open();
        //        using (SqlCommand sql_cmd = sql_con.CreateCommand())
        //        {
        //            sql_cmd.CommandText = cmd;
        //            sql_cmd.Parameters.AddRange(sql_params);
        //            SqlDataAdapter adapter = new SqlDataAdapter(sql_cmd);
        //            DataSet dataset = new DataSet();
        //            adapter.Fill(dataset);
        //            return dataset.Tables[0];

        //        }
        //    }
        //}


        /// <summary>
        /// with params SqlParameter[] sql_params
        /// </summary>
        public static int ExecuteNonQuery(string cmd, params SqlParameter[] sql_params)
        {
            using (SqlConnection sql_con = new SqlConnection(connection_str))
            {
                sql_con.Open();
                using (SqlCommand sql_cmd = sql_con.CreateCommand())
                {
                    sql_cmd.CommandText = cmd;
                    sql_cmd.Parameters.AddRange(sql_params);
                    return sql_cmd.ExecuteNonQuery();
                }
            }
        }


        public static object ExecuteScalar(string cmd, params SqlParameter[] sql_params)
        {
            using (SqlConnection sql_con = new SqlConnection(connection_str))
            {
                sql_con.Open();
                using (SqlCommand sql_cmd = sql_con.CreateCommand())
                {
                    sql_cmd.CommandText = cmd;
                    sql_cmd.Parameters.AddRange(sql_params);
                    return sql_cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable ExecuteDataTable(string cmd, params SqlParameter[] sql_params)
        {
            using (SqlConnection sql_con = new SqlConnection(connection_str))
            {
                sql_con.Open();
                using (SqlCommand sql_cmd = sql_con.CreateCommand())
                {
                    sql_cmd.CommandText = cmd;
                    sql_cmd.Parameters.AddRange(sql_params);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql_cmd);
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
