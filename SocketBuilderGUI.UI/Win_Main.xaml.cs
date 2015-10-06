using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


using EthanYuWPFKit.UI;
using SocketBuilderGUI.UI.StatusController;
using Model;
namespace SocketBuilderGUI.UI
{
    public partial class Win_Main : Window, IWinOpenClose
    {
        #region implement interface
        public bool win_opened { get; set; }
        public void WinInit() 
        {
            win_opened = true;
        }

        public void WinClose() 
        { 
            win_opened = false;
        }
        #endregion implement interface





        public Win_Main()
        {
            InitializeComponent();
            WinInit();
            StatCtrl_global.Instance.win_main = this;
            StatCtrl_win_main.Instance.Init();
            StatCtrl_win_material_db.Instance.Init();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            WinClose();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // do data binding here
            // materials
            StatCtrl_win_main.Instance.InitWinDataContext_Materials();
            
            // socket builder obj
            StatCtrl_win_main.Instance.InitWinDataContext_SocketBuilderObj();

            // status controller 
            StatCtrl_win_main.Instance.InitWinDataContext_StatusController();

            // combox automation1
            StatCtrl_win_main.Instance.InitWinDataContext_SocketLayer();

            // combox automation2
            StatCtrl_win_main.Instance.InitWinDataContext_PinCav();

            StatCtrl_win_main.Instance.InitWinDataContext_PinCavLib();
            StatCtrl_win_main.Instance.InitWinDataContext_MaterialNames();
        }




        // inner/public function ****************************************************
        void RemoveItems(List<Material> list)
        {
            StatCtrl_win_main.Instance.RemoveItems(list);
        }


        // ************** menu click
        private void Menu_Calculator_Click(object sender, RoutedEventArgs e)
        {
            StatCtrl_global.ShowWin<Win_Calculator>
                (ref StatCtrl_global.Instance.win_calculator);
        }
        private void Menu_Materials_Click(object sender, RoutedEventArgs e)
        {
            StatCtrl_global.ShowWin<Win_MaterialsDatabase>
                (ref StatCtrl_global.Instance.win_material_db);
        }


        ///************** button logic
        private void Btn_NewFile(object sender, RoutedEventArgs e)
        {

        }
        private void Btn_CloseFile(object sender, RoutedEventArgs e)
        {

        }
        private void Btn_Exit(object sender, RoutedEventArgs e)
        {

        }
        private void Btn_OpenFile(object sender, RoutedEventArgs e)
        {

        }
        private void Btn_SaveFile(object sender, RoutedEventArgs e)
        {

        }
        private void Btn_ClearFile(object sender, RoutedEventArgs e)
        {
        }




        // ******************* tab pages btn logic
        // ****************** Material part ********************
        private void Btn_NewMaterial_User_Click(object sender, RoutedEventArgs e)
        {
            StatCtrl_win_material_edit.Instance.Type = "new_user";
            StatCtrl_global.ShowDialogWin<Win_MaterialEdit>
                (ref StatCtrl_global.Instance.win_material_edit);
        }

        private void Btn_EditMaterial_User_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select one material item first.", "Notice", MessageBoxButton.OK);
                return;
            }
            if (datagrid.SelectedItems.Count > 1)
            {
                MessageBox.Show("You can only edit one item each time.", "Notice", MessageBoxButton.OK);
                return;
            }
            if (((Material)datagrid.SelectedItems[0]).Category == "system")
            {
                MessageBox.Show("You can only edit user defined materials here.", "Notice", MessageBoxButton.OK);
                return;
            }

            Material obj = (Material)((Material)datagrid.SelectedItems[0]).Clone();
            StatCtrl_win_main.Instance.CurrentEditItem = (Material)datagrid.SelectedItems[0];
            StatCtrl_win_material_edit.Instance.Type = "edit_user";
            StatCtrl_win_material_edit.Instance.CurrentEditMaterial = obj;

            StatCtrl_global.ShowDialogWin<Win_MaterialEdit>
                (ref StatCtrl_global.Instance.win_material_edit);
        }

        private void Btn_RemoveMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select one material item first.", "Notice", MessageBoxButton.OK);
                return;
            }



            List<Material> delete_list = new List<Material>();
            for (int i = 0; i < datagrid.SelectedItems.Count; i++)
            {
                delete_list.Add((Material)datagrid.SelectedItems[i]);
            }
            RemoveItems(delete_list);
        }





        // ***************** combox automation ******************

        private void comb_layer_material_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StatCtrl_win_main.Instance.UpdateWinDataContext_SocketLayer_MatType();
        }

        private void txt_total_socket_layers_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            StatCtrl_win_main.Instance.GenComb_SocketLayerNoList();
        }

        //private void btn_save_layer_data_Click(object sender, RoutedEventArgs e)
        //{
        //    StatCtrl_win_main.Instance.SaveLastLayerData();
        //}

        private void comb_socket_layer_no_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StatCtrl_win_main.Instance.UpdateLayerData();
        }

        private void comb_pincav_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StatCtrl_win_main.Instance.UpdatePinCavData();
        }

        private void comb_pincavlib_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StatCtrl_win_main.Instance.UpdatePinCavLibData();
        }












    }
}
