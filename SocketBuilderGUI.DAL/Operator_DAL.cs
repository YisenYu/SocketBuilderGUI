using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using EthanYuWPFKit.DAL;
using Model;
namespace EthanYuWPFKit.DAL
{
    public static class Operator_DAL
    {

        static Operator ToOperator(DataRow datarow)
        {
            Operator obj = new Operator();

            obj.Id = (Guid)datarow["id"];
            obj.User_name = (string)datarow["user_name"];
            obj.User_password = (string)datarow["user_password"];
            obj.Real_name = (string)datarow["real_name"];
            obj.Job_No = (string)SqlHelper.FromDbValue(datarow["job_No"]);
            obj.Licensor_id = (Guid?)SqlHelper.FromDbValue(datarow["licensor_id"]);
            obj.Licensor_real_name = (string)SqlHelper.FromDbValue(datarow["licensor_real_name"]);
            return obj;
        }


        public static void Insert(Operator operator_obj)
        {
            SqlHelper.ExecuteNonQuery(@"insert into T_operators(
                        id, 
                        user_name, 
                        user_password, 
                        real_name, 
                        job_No,
                        licensor_id, 
                        licensor_real_name)
                        values(
                        newid(), 
                        @user_name,
                        @user_password,
                        @real_name,  
                        @job_No,
                        @licensor_id,  
                        @licensor_real_name)",
                        new SqlParameter("@user_name", operator_obj.User_name),
                        new SqlParameter("@user_password", operator_obj.User_password),
                        new SqlParameter("@real_name", operator_obj.Real_name),
                        new SqlParameter("@job_No", SqlHelper.ToDbValue(operator_obj.Job_No)),
                        new SqlParameter("@licensor_id", SqlHelper.ToDbValue(operator_obj.Licensor_id)),
                        new SqlParameter("@licensor_real_name", SqlHelper.ToDbValue(operator_obj.Licensor_real_name)));
        }

        public static List<Operator> GetAll()
        {
            
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_operators");
            List<Operator> list = new List<Operator>(table.Rows.Count) ;
            for (int i = 0; i < table.Rows.Count;i++ )
            {
                list.Add(ToOperator(table.Rows[i]));
            }
            return list;
        }

        public static Operator GetByUserName(string user_name)
        {
            DataTable table = SqlHelper.ExecuteDataTable(
                @"select *from T_operators where
                user_name = @user_name",
                new SqlParameter("@user_name", user_name));
            if(table.Rows.Count <= 0)
            {
                return null;
            }
            else if (table.Rows.Count > 1)
            {
                throw new Exception("存在重复的用户名！");
            }
            else { return ToOperator(table.Rows[0]); }
        }

        public static void Update(Operator operator_obj)
        {
            SqlHelper.ExecuteNonQuery(@"update T_operators set 
                              user_name = @user_name, 
                              user_password = @user_password,
                              job_No = @job_No where
                              id = @id",
                              new SqlParameter("@user_name", operator_obj.User_name),
                              new SqlParameter("@user_password",operator_obj.User_password),
                              new SqlParameter("@job_No", operator_obj.Job_No),
                              new SqlParameter("@id", operator_obj.Id));
        }

        public static void DeleteById(Guid id)
        {
            SqlHelper.ExecuteNonQuery(@"delete from T_operators where id = @id",
                new SqlParameter("@id", id));
        }


        public static bool ValidateUniqueName(string name)
        {
            DataTable table = SqlHelper.ExecuteDataTable(@"select user_name from T_operators");
            if (table.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                foreach(DataRow item in table.Rows)
                {
                    if((string)item["user_name"] == name)
                        return false;
                }
                return true;
            }
        }

    }
}
