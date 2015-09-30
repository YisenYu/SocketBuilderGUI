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
    /// Win_MaterialEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Win_MaterialEdit : Window, IWinOpenClose
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
            #endregion

        }

        public void WinClose()
        {
            win_opened = false;
        }
        #endregion implement interface


        #region menber
        #endregion

        public Win_MaterialEdit()
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
    }
}
