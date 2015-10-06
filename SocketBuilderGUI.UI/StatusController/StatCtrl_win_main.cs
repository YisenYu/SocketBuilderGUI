using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.Windows;
using Model;
using System.ComponentModel;
using SocketBuilderGUI.DAL;
using EthanYuWPFKit.Util;
using SocketBuilderGUI.UI;
using EthanYuWPFKit.UI;
using System.Windows.Data;
using Xceed.Wpf.Toolkit;
namespace SocketBuilderGUI.UI.StatusController
{
    public class StatCtrl_win_main : SingletonProvider<StatCtrl_win_main>, INotifyPropertyChanged
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



        // constructor
        public StatCtrl_win_main() 
        {
            // material part start *******************************************
            list_material_sys = new List<Material>();
            list_material_user = new List<Material>();
            list_materials = new List<Material>();
            // load list_material_sys, list_material_user
            UpdateList_Material();




            // dataobject start *********************************************
            dataobject = new SocketBuilderObject();

            // combox item src start ****************************************
            Comb_SocketLayerNo = new List<string>();
            comb_socket_layer_data = new SocketLayers();
        }





        #region **************** Status Controller Data Binding *************************
        // layer thickness
        double saved_layers_thickness;
        public double SavedLayersThickness
        {
            get { return saved_layers_thickness; }// using GetCurrentThicknessFromSocketLayerList
            set
            {
                saved_layers_thickness = value;
                dataobject.TotalHeight = saved_layers_thickness;// no data binding used, directly assignment
            }
        }
        void GetCurrentThicknessFromSocketLayerList()
        {
            // NOTICE !!!
            // when value changed event occurs, the data source has not be updated yet!
            // using Text instead!
            int num = CommonHelper.StringToInt(StatCtrl_global.Instance.win_main.txt_total_socket_layers.Text);
            double temp = 0;
            for (int i = 0; i < num; i++)//(int i = 0; i < dataobject.TotalLayers; i++)
            {
                if (dataobject.ListSocketLayers[i].Keys.Count == 0) continue;
                temp += double.Parse(dataobject.ListSocketLayers[i]["LayerThickness"]);
            }
            SavedLayersThickness = temp;
        }


        string pin_name;
        public string PinName
        {
            get { return pin_name; }
            set
            {
                pin_name = value;// no data binding used, directly assignment
                StatCtrl_global.Instance.win_main.txt_lib_pin_name.Text = pin_name;
            }
        }

        string cav_name;
        public string CavName
        {
            get { return cav_name; }
            set
            {
                cav_name = value;// no data binding used, directly assignment
                StatCtrl_global.Instance.win_main.txt_lib_cav_name.Text = cav_name;
            }
        }





        public void InitWinDataContext_StatusController()
        {
            //Binding bind_min_layer_total_thickness = new Binding();
            //bind_min_layer_total_thickness.Source = this;
            //bind_min_layer_total_thickness.Path = new PropertyPath("SavedLayersThickness");
            //BindingOperations.SetBinding(StatCtrl_global.Instance.win_main.txt_total_layer_height,
            //    DoubleUpDown.MinimumProperty, bind_min_layer_total_thickness);




        }


        


        #endregion

        #region ************* Material Part **********************

        // material part start *******************************************
        List<Material> list_material_user;
        List<Material> list_material_sys;
        List<Material> list_materials;
        public Material CurrentEditItem { set; get; }

        public List<string> list_material_names;

        public void InitWinDataContext_MaterialNames()
        {
            UpdateWinDataContext_MaterialNames();
        }
        public void UpdateWinDataContext_MaterialNames()// called when list_material changed
        {
            list_material_names = new List<string>(list_materials.Count);
            foreach (Material obj in list_materials)
            {
                list_material_names.Add(obj.Name);
            }

            StatCtrl_global.Instance.win_main.comb_pinlib_material.ItemsSource = null;
            StatCtrl_global.Instance.win_main.comb_pinlib_material.ItemsSource = list_material_names;
            StatCtrl_global.Instance.win_main.comb_pad_material_pcb.ItemsSource = null;
            StatCtrl_global.Instance.win_main.comb_pad_material_pcb.ItemsSource = list_material_names;
            StatCtrl_global.Instance.win_main.comb_pad_material_pkg.ItemsSource = null;
            StatCtrl_global.Instance.win_main.comb_pad_material_pkg.ItemsSource = list_material_names;
            StatCtrl_global.Instance.win_main.comb_diel_material_pcb.ItemsSource = null;
            StatCtrl_global.Instance.win_main.comb_diel_material_pcb.ItemsSource = list_material_names;
            StatCtrl_global.Instance.win_main.comb_diel_material_pkg.ItemsSource = null;
            StatCtrl_global.Instance.win_main.comb_diel_material_pkg.ItemsSource = list_material_names;

        }

        public void InitWinDataContext_Materials()// win only call it when loaded
        {
            // data has been already prepared when constructing this obj
            // only do data binding here
            StatCtrl_global.Instance.win_main.datagrid.ItemsSource = list_materials;
        }
        void UpdateWinDataContext_Materials()
        {
            // list_materials has been updated already
            UpdateList_Material();
            StatCtrl_global.Instance.win_main.datagrid.ItemsSource = null;
            StatCtrl_global.Instance.win_main.datagrid.ItemsSource = list_materials;
            UpdateWinDataContext_SocketLayer_MatType();
            UpdateWinDataContext_MaterialNames();
        }
        void UpdateList_Material()
        {
            // list_material_sys has been updated already
            // list_material_user has been updated already

            // overriding only occurs when initialization
            list_materials = CheckOverrideItems(list_material_sys, list_material_user,
                "You have items which have two copies both in the system and user category, you can only keep these items in one category. Let the system material items override the user defined items please click OK, or vice versa");
        }

        // helper
        List<Material> CheckOverrideItems(List<Material> list_new, List<Material> list_old, string msg)
        {
            List<string> list_rep_names = new List<string>();
            List<Material> list_rep_obj = new List<Material>();
            for (int i = 0; i < list_new.Count; i++)
            {
                if (list_old.Contains(list_new[i]))
                {
                    list_rep_names.Add(list_new[i].Name);
                    list_rep_obj.Add(list_new[i]);
                }
            }
            if (list_rep_names.Count != 0)
            {
                MessageBoxResult res =
                    System.Windows.MessageBox.Show("Naming conflicts detected: \"" + string.Join(", ", list_rep_names.ToArray()) + ".\"\n" + msg,
                    "Warning", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.No)
                {
                    foreach (Material obj in list_rep_obj)
                    {
                        list_new.Remove(obj);
                    }
                }
            }
            if (list_new.Count == 0) return list_old;

            return list_new.Union(list_old).ToList<Material>();
        }




        // add delete edit
        public void AddSysMaterialList(List<Material> list)
        {
            list_material_sys = CheckOverrideItems(list, list_material_sys,
                "You added item(s) which already exists, do you want to override them?");
            UpdateWinDataContext_Materials();
            UpdateWinDataContext_MaterialNames();

        }
        public void AddUserMaterial(Material obj)
        {
            list_material_user.Add(obj);
            UpdateWinDataContext_Materials();
            UpdateWinDataContext_MaterialNames();
        }
        public void RemoveItems(List<Material> list)
        {
            foreach (Material obj in list)
            {
                if (obj.Category == "system")
                {
                    list_material_sys.Remove(obj);
                }
                else
                {
                    list_material_user.Remove(obj);
                }
                list_materials.Remove(obj);
            }
            UpdateWinDataContext_Materials();
            UpdateWinDataContext_MaterialNames();
        }


        public void EditUserMaterial(Material obj)
        {
            for (int i = 0; i < list_material_user.Count; i++)
            {
                if (list_material_user[i].Name == CurrentEditItem.Name)
                {
                    list_material_user[i] = obj;
                    break;
                }
            }
            UpdateWinDataContext_Materials();
            UpdateWinDataContext_MaterialNames();
        }

        // validation
        public bool ValidateUnique_User(string name)
        {
            for (int i = 0; i < list_material_user.Count; i++)
            {
                if (list_material_user[i].Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region **************** SocketBuilderObject part ****************************
        SocketBuilderObject dataobject;
        public void InitWinDataContext_SocketBuilderObj()// win only call it when loaded
        {
            StatCtrl_global.Instance.win_main.grid.DataContext = dataobject;
        }
        #endregion




        #region ******************** Combox Automation1 : Socket Layers ****************************
        // two kinds of binding exists
        // 1: data context, the selected item
        // 2: items source, the list of optional items


        // UI data binding


        // initialization
        public void InitWinDataContext_SocketLayer()// called only once when loaded
        {
            comb_socket_layer_data = new SocketLayers();
            UpdateWinDataContext_LayerData();
            StatCtrl_global.Instance.win_main.comb_layer_material_name.ItemsSource = GetMaterialNamesByType(null);
        }
        void UpdateWinDataContext_LayerData()// called when comb_socket_layer_data is renewed
        {
            StatCtrl_global.Instance.win_main.txt_layer_thickness.DataContext = null;
            StatCtrl_global.Instance.win_main.txt_layer_thickness.DataContext = comb_socket_layer_data;


            StatCtrl_global.Instance.win_main.comb_layer_material_type.DataContext = null;
            StatCtrl_global.Instance.win_main.comb_layer_material_type.DataContext = comb_socket_layer_data;

            StatCtrl_global.Instance.win_main.comb_layer_material_name.DataContext = null;
            StatCtrl_global.Instance.win_main.comb_layer_material_name.DataContext = comb_socket_layer_data;
        }



        // materials
        public void UpdateWinDataContext_SocketLayer_MatType()// called when list_material changed or comb_type changed
        {
            string selected_type = CommonHelper.ObjectToString(StatCtrl_global.Instance.win_main.comb_layer_material_type.SelectedItem);

            StatCtrl_global.Instance.win_main.comb_layer_material_name.ItemsSource = null;
            StatCtrl_global.Instance.win_main.comb_layer_material_name.ItemsSource =
                GetMaterialNamesByType(selected_type);

            // NOTICE!!!
            // avoid to assign string directly to the data source
            // comb_socket_layer_data.LayerMaterialName = "";
            StatCtrl_global.Instance.win_main.comb_layer_material_name.Text = "";
        }
        List<string> GetMaterialNamesByType(string type)
        {
            List<string> list = new List<string>();
            if (string.IsNullOrEmpty(type))
            {
                foreach (Material obj in list_materials)
                {
                    list.Add(obj.Name);
                }
            }
            else
            {
                foreach (Material obj in list_materials)
                {
                    if (obj.Type == type)
                    {
                        list.Add(obj.Name);
                    }
                }
            }
            return list;
        }



        // layer no list
        List<string> comb_socket_layer_no;
        List<string> Comb_SocketLayerNo
        {
            get { return comb_socket_layer_no; }
            set
            {
                comb_socket_layer_no = value;
                StatCtrl_global.Instance.win_main.comb_socket_layer_no.ItemsSource = null;
                StatCtrl_global.Instance.win_main.comb_socket_layer_no.ItemsSource = comb_socket_layer_no;
            }
        }
        public void GenComb_SocketLayerNoList()// total layer num changed
        {
            //int num = int.Parse(StatCtrl_global.Instance.win_main.txt_total_socket_layers.Text);
            int num = CommonHelper.StringToInt(StatCtrl_global.Instance.win_main.txt_total_socket_layers.Text);

            List<string> list = new List<string>(num);//dataobject.TotalLayers
            for (int i = 0; i<num; i++)
            {
                list.Add((i+1).ToString());
            }
            Comb_SocketLayerNo = list;

            // NOTICE !!!
            // when value changed event occurs, the data source has not be updated yet!
            // using Text instead!
            // if (dataobject.ListSocketLayers.Count < dataobject.TotalLayers)
            // for (int i = 1; i <= dataobject.TotalLayers - dataobject.ListSocketLayers.Count; i++)
            if (dataobject.ListSocketLayers.Count < num)
            {
                for (int i = 1; i <= num - dataobject.ListSocketLayers.Count; i++)
                {
                    SocketLayers data = new SocketLayers();
                    dataobject.ListSocketLayers.Add(data.ToDictionary());
                }
            }
            GetCurrentThicknessFromSocketLayerList();

        }


        // layer data saving
        SocketLayers comb_socket_layer_data;

        public void SaveLastLayerData()
        {
            string layer_no_str = CommonHelper.ObjectToString(StatCtrl_global.Instance.win_main.comb_socket_layer_no.SelectedItem);
            if (string.IsNullOrEmpty(layer_no_str)) return;

            int current_no = int.Parse(layer_no_str);
            int current_len = dataobject.ListSocketLayers.Count;

            if (current_no > current_len)
            {
                for (int i = 1; i <= current_no - current_len; i++ )
                {
                    //dataobject.ListSocketLayers.Add(new Dictionary<string, string>());
                    SocketLayers data = new SocketLayers();
                    dataobject.ListSocketLayers.Add(data.ToDictionary());
                }
            }
            dataobject.ListSocketLayers[current_no - 1] = comb_socket_layer_data.ToDictionary();
            GetCurrentThicknessFromSocketLayerList();
        }

        // layer No. changed
        public void UpdateLayerData()
        {
            //string layer_no_str = CommonHelper.ObjectToString(StatCtrl_global.Instance.win_main.comb_socket_layer_no.SelectedItem);
            //if (string.IsNullOrEmpty(layer_no_str)) return;

            //current_no = int.Parse(layer_no_str);
            //int current_len = dataobject.ListSocketLayers.Count;

            //if (current_no <= current_len)
            //{
            //    comb_socket_layer_data = SocketLayers.ToObject(dataobject.ListSocketLayers[current_no - 1]);
            //}
            //else
            //{
            //    comb_socket_layer_data = new SocketLayers();
            //}
            //UpdateWinDataContext_LayerData();


            string num_pre_str = CommonHelper.ObjectToString(StatCtrl_global.Instance.win_main.comb_socket_layer_no.Text);
            string num_current_str = CommonHelper.ObjectToString(StatCtrl_global.Instance.win_main.comb_socket_layer_no.SelectedItem);
            if (!string.IsNullOrEmpty(num_pre_str))
            {
                // step1: save data at the old index
                int num_pre = CommonHelper.StringToInt(num_pre_str);
                int current_len = dataobject.ListSocketLayers.Count;

                if (num_pre > current_len)
                {
                    for (int i = 1; i <= num_pre - current_len; i++)
                    {
                        SocketLayers data = new SocketLayers();
                        dataobject.ListSocketLayers.Add(data.ToDictionary());
                    }
                }
                dataobject.ListSocketLayers[num_pre - 1] = comb_socket_layer_data.ToDictionary();
                GetCurrentThicknessFromSocketLayerList();
            }
            if (!string.IsNullOrEmpty(num_current_str))
            {
                // step2: load data at the new index
                int num_current = CommonHelper.StringToInt(num_current_str);
                int current_len = dataobject.ListSocketLayers.Count;
                if (num_current <= current_len)
                {
                    // load
                    comb_socket_layer_data = SocketLayers.ToObject(dataobject.ListSocketLayers[num_current - 1]);
                }
                else
                {
                    // new
                    comb_socket_layer_data = new SocketLayers();
                }
            }
            UpdateWinDataContext_LayerData();
        }

        #endregion


        #region ************ Combox Automation2: Three different types of the PinCav *************************
        PinCavInfo one_type_pincav_data;

        public void InitWinDataContext_PinCav()
        {
            one_type_pincav_data = new PinCavInfo();
            dataobject.ListPinCavInfo.Add(one_type_pincav_data.ToDictionary());
            one_type_pincav_data = new PinCavInfo();
            dataobject.ListPinCavInfo.Add(one_type_pincav_data.ToDictionary());
            one_type_pincav_data = new PinCavInfo();
            dataobject.ListPinCavInfo.Add(one_type_pincav_data.ToDictionary());

            one_type_pincav_data = new PinCavInfo();
            UpdateWinDataContext_PinCav();
        }
        public void UpdateWinDataContext_PinCav()
        {
            StatCtrl_global.Instance.win_main.grid_pincav.DataContext = null;
            StatCtrl_global.Instance.win_main.grid_pincav.DataContext = one_type_pincav_data;
        }

        public void UpdatePinCavData()
        {
            // NOTICE !!!
            // when combox selection changed
            // data source may not be updated!
            // and the Text has not be assigned either, maybe equals to null!
            // Text records the last selected string, now the newly selected!
            // SelectedItem records the newly selected string !

            // when using changed event, txtbox is different with combox

            string num_pre_str = CommonHelper.ObjectToString(StatCtrl_global.Instance.win_main.comb_pincav_type.Text);
            string num_current_str = CommonHelper.ObjectToString(StatCtrl_global.Instance.win_main.comb_pincav_type.SelectedItem);
            if (!string.IsNullOrEmpty(num_pre_str))
            {
                // save data at the old index
                int num_pre = CommonHelper.StringToInt(num_pre_str);
                dataobject.ListPinCavInfo[num_pre - 1] = one_type_pincav_data.ToDictionary();
            }
            if (!string.IsNullOrEmpty(num_current_str))
            {
                // load data at the new index
                int num_current = CommonHelper.StringToInt(num_current_str);
                one_type_pincav_data = PinCavInfo.ToObject(dataobject.ListPinCavInfo[num_current - 1]);
            }

            UpdateWinDataContext_PinCav();

            // NOTICE !!!
            // List<T> list = new list<string>(num)
            // Does not mean list.Count == num !
            
            
            
        }




        #endregion


        #region ************ Combox Automation3: Three different types of the PinCavLib *************************
        PinCavLibInfo one_type_pincavlib_data;


        public void InitWinDataContext_PinCavLib()
        {
            one_type_pincavlib_data = new PinCavLibInfo();
            dataobject.ListPinCavLibInfo.Add(one_type_pincavlib_data.ToDictionary());
            one_type_pincavlib_data = new PinCavLibInfo();
            dataobject.ListPinCavLibInfo.Add(one_type_pincavlib_data.ToDictionary());
            one_type_pincavlib_data = new PinCavLibInfo();
            dataobject.ListPinCavLibInfo.Add(one_type_pincavlib_data.ToDictionary());

            one_type_pincavlib_data = new PinCavLibInfo();
            UpdateWinDataContext_PinCavLib();
        }
        public void UpdateWinDataContext_PinCavLib()
        {
            StatCtrl_global.Instance.win_main.grid_pincavlib.DataContext = null;
            StatCtrl_global.Instance.win_main.grid_pincavlib.DataContext = one_type_pincavlib_data;

        }

        public void UpdatePinCavLibData()
        {
            string num_pre_str = CommonHelper.ObjectToString(StatCtrl_global.Instance.win_main.comb_pincavlib_type.Text);
            string num_current_str = CommonHelper.ObjectToString(StatCtrl_global.Instance.win_main.comb_pincavlib_type.SelectedItem);
            if (!string.IsNullOrEmpty(num_pre_str))
            {
                // save data at the old index
                int num_pre = CommonHelper.StringToInt(num_pre_str);
                dataobject.ListPinCavLibInfo[num_pre - 1] = one_type_pincavlib_data.ToDictionary();
            }
            if (!string.IsNullOrEmpty(num_current_str))
            {
                // load data at the new index
                int num_current = CommonHelper.StringToInt(num_current_str);
                one_type_pincavlib_data = PinCavLibInfo.ToObject(dataobject.ListPinCavLibInfo[num_current - 1]);


                // load pin/cav names
                PinName = dataobject.ListPinCavInfo[num_current - 1]["PinName"];
                CavName = dataobject.ListPinCavInfo[num_current - 1]["CavName"];
            }

            UpdateWinDataContext_PinCavLib();

            // NOTICE !!!
            // List<T> list = new list<string>(num)
            // Does not mean list.Count == num !



        }




        #endregion















    }
}
