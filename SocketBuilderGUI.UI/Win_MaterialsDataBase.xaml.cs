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
    /// <summary>
    /// Win_MaterialsDatabase.xaml 的交互逻辑
    /// </summary>
    public partial class Win_MaterialsDatabase : Window, IWinOpenClose
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


        // constructor and closing ************************************
        public Win_MaterialsDatabase()
        {
            InitializeComponent();
            WinInit();
            StatCtrl_win_material_db.Instance.Init();
        }
        /// closing
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            WinClose();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StatCtrl_win_material_db.Instance.InitWinDataContext();
        }




        // inner function ************************************************
        void DeleteItems(List<Material> list)
        {
            StatCtrl_win_material_db.Instance.DeleteItems(list);
        }
        void Search(string type, string name)
        {
            StatCtrl_win_material_db.Instance.Search(type, name);
        }
        void SelectedDone()
        {
            StatCtrl_win_material_db.Instance.SelectedDone();
            Close();
        }



        /// button logic *************************************************
        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            StatCtrl_win_material_edit.Instance.Type = "new_sys";
            StatCtrl_global.ShowDialogWin<Win_MaterialEdit>
                (ref StatCtrl_global.Instance.win_material_edit);
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
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

            // NOTICE: must use CLONE
            Material obj = (Material)((Material)datagrid.SelectedItems[0]).Clone();
            StatCtrl_win_material_db.Instance.CurrentEditItem = (Material)datagrid.SelectedItems[0];
            StatCtrl_win_material_edit.Instance.Type = "edit_sys";
            StatCtrl_win_material_edit.Instance.CurrentEditMaterial = obj;
            
            StatCtrl_global.ShowDialogWin<Win_MaterialEdit>
                (ref StatCtrl_global.Instance.win_material_edit);
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select one material item first.", "Notice", MessageBoxButton.OK);
                return;
            }
            if(MessageBox.Show("Are you sure to delete?", "Warning", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                return;
            }
            // NOTICE: datagrid.SelectedItems.Count will change at every loop
            // datagrid.SelectedItems and its data source, i.e. list_material_sys will change simultaneously
            //for (int i = 0; i < datagrid.SelectedItems.Count; i++)
            //{
            //    DeleteItem((datagrid.SelectedItems));
            //}

            List<Material> delete_list = new List<Material>();
            for (int i = 0; i < datagrid.SelectedItems.Count; i++ )
            {
                delete_list.Add((Material)datagrid.SelectedItems[i]);
            }
            DeleteItems(delete_list);
            
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            Search(comb_type.Text.ToString(), txt_name.Text.ToString().Trim());
            cb_selectall.IsChecked = false;
        }

        private void comb_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search(comb_type.SelectedItem.ToString(), txt_name.Text.ToString().Trim());
        }

        private void Btn_SelectedDone_Click(object sender, RoutedEventArgs e)
        {
            SelectedDone();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            bool check = (cb_selectall.IsChecked == true)? true:false;
            if (datagrid.SelectedItems.Count == 0)
            {
                StatCtrl_win_material_db.Instance.CheckBox4AllItems(check);
            }
            else
            {
                for (int i = 0; i < datagrid.SelectedItems.Count; i++)
                {
                    ((Material)datagrid.SelectedItems[i]).Selected = check;
                }
            }

        }




    }
}
