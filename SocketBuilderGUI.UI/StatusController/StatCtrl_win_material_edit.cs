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
    public class StatCtrl_win_material_edit : SingletonProvider<StatCtrl_win_material_edit>, INotifyPropertyChanged
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



        public StatCtrl_win_material_edit() 
        {
        }



        Material current_edit_material;
        public Material CurrentEditMaterial
        {
            get
            {
                return current_edit_material;
            }
            set
            {
                current_edit_material = value;
                OriginalName = current_edit_material.Name;
            }
        }
        public string OriginalName { get; set; }
        public string Title { get; set; }
        string type;
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                switch (type)
                {
                    case "new_sys":
                        Title = "New System Material";
                        CurrentEditMaterial = new Material();
                        break;
                    case "new_user":
                        Title = "New User Material";
                        CurrentEditMaterial = new Material();
                        CurrentEditMaterial.Category = "user";
                        break;
                    case "edit_sys":
                        Title = "Edit System Material";
                        break;
                    case "edit_user":
                        Title = "Edit User Material";
                        break;
                }
            }
        }


        public void UpdateMaterialInput()
        {
            if (type == "new_sys")
            {
                StatCtrl_win_material_db.Instance.NewItem(CurrentEditMaterial);
            }
            else if(type == "edit_sys")
            {
                StatCtrl_win_material_db.Instance.EditItem(CurrentEditMaterial);
            }
            else if (type == "new_user")
            {
                StatCtrl_win_main.Instance.AddUserMaterial(CurrentEditMaterial);
            }
            else if (type == "edit_user")
            {
                StatCtrl_win_main.Instance.EditUserMaterial(CurrentEditMaterial);
            }
        }

        public void InitWinDatasrc()
        {
            StatCtrl_global.Instance.win_material_edit.grid.DataContext = null;
            StatCtrl_global.Instance.win_material_edit.grid.DataContext = CurrentEditMaterial;
        }

    }
}
