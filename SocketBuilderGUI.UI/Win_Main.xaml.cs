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


using EthanYuWPFKit.BLL;
using EthanYuWPFKit.UI;
namespace SocketBuilderGUI.UI
{
    /// <summary>
    /// Win_Main.xaml 的交互逻辑
    /// </summary>
    public partial class Win_Main : Window, IWinOpenClose
    {
        #region implement interface
        public bool win_opened { get; set; }
        public void WinInit() 
        {
            #region basic init
            win_opened = true;
            #endregion

            #region model preparations and datacontext setting
            #endregion


            #region local model & controller preparations and datacontext setting
            StatCtrl_win_template.Instance.Init();
            //parent_grid.DataContext = StatCtrl_register.Instance;
            //txtbox_name.DataContext = StatCtrl_register.Instance.New_user;
            //txtbox_job_no.DataContext = StatCtrl_register.Instance.New_user;
            #endregion

        }

        public void WinClose() 
        { 
            win_opened = false;
        }
        #endregion implement interface


        #region menber
        #endregion


        /// creating
        /// constructor and init
        public Win_Main()
        {
            InitializeComponent();
            WinInit();
        }

        /// closing
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            WinClose();
        }


        /// button logic
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
    }
}
