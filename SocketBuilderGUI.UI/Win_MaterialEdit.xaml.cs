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
namespace SocketBuilderGUI.UI
{

    public partial class Win_MaterialEdit : Window, IWinOpenClose
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


        // open and close ************************************************
        public Win_MaterialEdit()
        {
            InitializeComponent();
            WinInit();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            WinClose();
        }
        // loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateTitle();
            StatCtrl_win_material_edit.Instance.InitWinDatasrc();
        }




        // inner function ************************************************
        void UpdateTitle()
        {
            Title = StatCtrl_win_material_edit.Instance.Title;
        }
        void UpdateInput()
        {
            StatCtrl_win_material_edit.Instance.UpdateMaterialInput();
            Close();
        }
        bool ValidateUnique_Sys(string name)
        {
            return StatCtrl_win_material_db.Instance.ValidateUnique_Sys(name);
        }
        bool ValidateUnique_User(string name)
        {
            return StatCtrl_win_main.Instance.ValidateUnique_User(name);
        }

        



        /// button logic ************************************************
        private void Btn_Done_Click(object sender, RoutedEventArgs e)
        {
            // no type
            if (comb_type.Text == null)
            {
                MessageBox.Show("Please select the type of the material.", "Notice", MessageBoxButton.OK);
                return;
            }

            string input_name = txt_name.Text.ToString().Trim();

            // no name
            if (string.IsNullOrEmpty(input_name))
            {
                MessageBox.Show("Please Enter the name of the material.", "Notice", MessageBoxButton.OK);
                return;
            }

            // is edit
            if (input_name == StatCtrl_win_material_edit.Instance.OriginalName)
            {
                UpdateInput();
                return;
            }


            // unique naming validation
            if (ValidateUnique_Sys(input_name))// system
            {
                MessageBox.Show("This name is already existed in system material database.", "Notice", MessageBoxButton.OK);
                return;
            }
            

            if (StatCtrl_win_material_edit.Instance.Type.Contains("user"))
            {
                if (ValidateUnique_User(input_name))// user
                {
                    MessageBox.Show("This name is already existed in the current project.", "Notice", MessageBoxButton.OK);
                    return;
                }
            }
            UpdateInput();
        }

    }
}
