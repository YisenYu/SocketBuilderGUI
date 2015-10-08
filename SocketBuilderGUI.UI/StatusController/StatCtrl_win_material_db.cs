using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EthanYuWPFKit.Util;
using System.ComponentModel;
using Model;
using SocketBuilderGUI.DAL;



namespace SocketBuilderGUI.UI.StatusController
{
    public class StatCtrl_win_material_db : SingletonProvider<StatCtrl_win_material_db>, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implement
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion



        //******************** NEW *************************
        public StatCtrl_win_material_db() 
        {
            list_material_sys = new List<Material>();
            list_material_names = new List<string>();
            
            // data binding is called when loaded
            // but the data must be prepared when constructor is called
            // this process can not have any operation related to the corresponding window
            UpdateList();
        }

        List<Material> list_material_sys;
        List<string> list_material_names;// this is the material names in db, not in the current datagrid
        public Material CurrentEditItem { set; get; }




        // inner
        void RenewMaterialList()
        {
            list_material_names = new List<string>(list_material_sys.Count);
            for (int i = 0; i < list_material_sys.Count; i++)
            {
                list_material_names.Add(list_material_sys[i].Name);
            }
        }
        void UpdateList()
        {
            list_material_sys = Material_DAL.GetAll();
            RenewMaterialList();
        }
        public void InitWinDataContext()// win only call it when loaded
        {
            // data has been already prepared when constructing this obj
            // only do data binding here
            StatCtrl_global.Instance.win_material_db.datagrid.ItemsSource = list_material_sys;
        }
        void UpdateWinDataContext()
        {
            StatCtrl_global.Instance.win_material_db.datagrid.ItemsSource = null;
            StatCtrl_global.Instance.win_material_db.datagrid.ItemsSource = list_material_sys;
        }




        // add delete search edit
        public void NewItem(Material obj)
        {
            list_material_sys.Add(obj);
            list_material_names.Add(obj.Name);
            Material_DAL.Insert(obj);
            UpdateWinDataContext();
        }
        public void DeleteItems(List<Material> list)
        {
            foreach(Material obj in list)
            {
                list_material_sys.Remove(obj);
                list_material_names.Remove(obj.Name);
                Material_DAL.DeleteById(obj.ID);
            }
            UpdateWinDataContext();
        }
        public void Search(string type, string name)
        {
            if ((string.IsNullOrEmpty(type)||type == "all") && string.IsNullOrEmpty(name))
            {
                list_material_sys = Material_DAL.GetAll();
                RenewMaterialList();
            } 
            else
            {
                list_material_sys = Material_DAL.Search(null, type, name);
            }
            UpdateWinDataContext();
        }
        public void EditItem(Material obj)
        {
            for (int i = 0; i < list_material_names.Count; i++ )
            {
                if (list_material_names[i] == CurrentEditItem.Name)
                {
                    list_material_names[i] = obj.Name;
                    //list_material_sys[i] = obj;
                    break;
                }
            }

            Material_DAL.Update(obj);
            list_material_sys = Material_DAL.Search(null, 
                StatCtrl_global.Instance.win_material_db.comb_type.Text.Trim(),
                StatCtrl_global.Instance.win_material_db.txt_name.Text.Trim());



            UpdateWinDataContext();
        }







        public void CheckBox4AllItems(bool cb)
        {
            for (int i = 0; i < list_material_sys.Count; i++ )
            {
                list_material_sys[i].Selected = cb;
            }
        }


        public bool ValidateUnique_Sys(string name)
        {
            return list_material_names.Contains(name);
        }


        public void SelectedDone()
        {
            List<Material> list_selected = new List<Material>(list_material_sys.Count);
            for (int i = 0; i < list_material_sys.Count; i++ )
            {
                if (list_material_sys[i].Selected)
                { list_selected.Add(list_material_sys[i]); }

            }
            StatCtrl_win_main.Instance.AddSysMaterialList(list_selected);
            
        }
        
    }
}
