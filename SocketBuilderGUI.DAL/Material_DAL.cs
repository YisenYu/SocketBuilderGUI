using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using EthanYuWPFKit.DAL;
using Model;
using System.Data;
using System.Data.SQLite;
namespace SocketBuilderGUI.DAL
{
    public static class Material_DAL
    {

        // from db to obj
        static Material ToMaterialObj(DataRow datarow)
        {
            Material obj = new Material();

            obj.ID = new Guid(datarow["id"].ToString());
            obj.Conductivity = (double)datarow["conductivity"];
            obj.LossTangent = (double)datarow["loss_tangent"];
            obj.Name = (string)datarow["name"];
            obj.Permeability = (double)datarow["permeability"];
            obj.Permittivity = (double)datarow["permittivity"];
            obj.Type = (string)datarow["type"];
            return obj;
        }

        public static List<Material> GetAll()
        {
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_materials_sys");
            List<Material> list = new List<Material>(table.Rows.Count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(ToMaterialObj(table.Rows[i]));
            }
            return list;
        }


        public static void Insert(Material obj)
        {
            SqlHelper.ExecuteNonQuery(@"insert into T_materials_sys(
                        id,
                        name, 
                        type, 
                        permittivity, 
                        permeability,
                        conductivity, 
                        loss_tangent)
                        values(
                        @id, 
                        @name,
                        @type,
                        @permittivity,  
                        @permeability,
                        @conductivity,  
                        @loss_tangent)",
                        new SQLiteParameter("@id", Guid.NewGuid().ToString()),
                        new SQLiteParameter("@name", obj.Name),
                        new SQLiteParameter("@type", obj.Type),
                        new SQLiteParameter("@permittivity", obj.Permittivity),
                        new SQLiteParameter("@permeability", obj.Permeability),
                        new SQLiteParameter("@conductivity", obj.Conductivity),
                        new SQLiteParameter("@loss_tangent", obj.LossTangent)
                        );
        }

        public static void DeleteById(Guid id)
        {
            SqlHelper.ExecuteNonQuery(@"delete from T_materials_sys where id = @id",
                new SQLiteParameter("@id", id.ToString()));
        }


        public static void Update(Material obj)
        {
            SqlHelper.ExecuteNonQuery(@"update T_materials_sys set 
                              name = @name, 
                              type = @type,
                              permittivity = @permittivity,
                              permeability = @permeability, 
                              conductivity = @conductivity,
                              loss_tangent = @loss_tangent
                              where 
                              id = @id",
                            new SQLiteParameter("@name", obj.Name),
                            new SQLiteParameter("@type", obj.Type),
                            new SQLiteParameter("@permittivity", obj.Permittivity),
                            new SQLiteParameter("@permeability", obj.Permeability),
                            new SQLiteParameter("@conductivity", obj.Conductivity),
                            new SQLiteParameter("@loss_tangent", obj.LossTangent),
                            new SQLiteParameter("@id", obj.ID.ToString()));
        }



        public static bool ValidateUniqueName(string name)
        {
            DataTable table = SqlHelper.ExecuteDataTable(@"select name from T_materials_sys");
            if (table.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                foreach (DataRow item in table.Rows)
                {
                    if ((string)item["name"] == name)
                        return false;
                }
                return true;
            }
        }



        public static List<Material> Search(string category, string type, string name)
        {
            StringBuilder cmdtxt = new StringBuilder("where ");
            List<SQLiteParameter> conditions_list = new List<SQLiteParameter>();

            if (!string.IsNullOrEmpty(category) && category != "all")
            {
                cmdtxt.Append("category = @category");
                cmdtxt.Append(" and ");
                conditions_list.Add(new SQLiteParameter("@category", category));
            }
            if (!string.IsNullOrEmpty(type) && type != "all")
            {
                cmdtxt.Append("type = @type");
                cmdtxt.Append(" and ");
                conditions_list.Add(new SQLiteParameter("@type", type));
            }
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name) && name != "all")
            {
                cmdtxt.Append("name = @name");
                cmdtxt.Append(" and ");
                conditions_list.Add(new SQLiteParameter("@name", name));
            }
            if (cmdtxt.Length == 6)
            {
                cmdtxt = new StringBuilder();
            }
            else
            {
                cmdtxt.Remove(cmdtxt.Length - 5, 5);
            }



            SQLiteParameter[]  conditions_array = new SQLiteParameter[conditions_list.Count];
            for (int i = 0; i < conditions_list.Count; i++)
            {
                conditions_array[i] = conditions_list[i];
            }

            List<Material> list = new List<Material>();
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_materials_sys " + cmdtxt + " order by name", conditions_array);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(ToMaterialObj(table.Rows[i]));
            }
            return list;
        }

    }
}
