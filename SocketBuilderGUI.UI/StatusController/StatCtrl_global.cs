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
namespace SocketBuilderGUI.UI.StatusController
{
    public class StatCtrl_global : SingletonProvider<StatCtrl_global>, INotifyPropertyChanged
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

        #region menber windows
        public Win_Calculator win_calculator;
        public Win_MaterialEdit win_material_edit;
        public Win_MaterialsDatabase win_material_db;
        public Win_Main win_main;
        #endregion





        // constructor
        public StatCtrl_global() 
        {
        }


        #region menber_functions
        public static void ShowWin<T>(ref T win) where T : Window, IWinOpenClose, new()
        {
            if (win == null)
            {
                win = new T();
                win.Show();
            }
            else if (win.win_opened == false)
            {
                win = new T();
                win.Show();
            }
            else if (win.win_opened == true)
            {
                win.Activate();
            }
        }
        public static void ShowDialogWin<T>(ref T win) where T : Window, IWinOpenClose, new()
        {
            if (win == null)
            {
                win = new T();
                win.ShowDialog();
            }
            else if (win.win_opened == false)
            {
                win = new T();
                win.ShowDialog();
            }
        }

        public void CloseWin<T>(T win) where T:Window, IWinOpenClose
        {
            if (win == null) return;
            if (win.win_opened == false) return;
            win.Close();
        }

        public void CloseAllSubWin()
        {
            CloseWin<Win_Calculator>(win_calculator);
            CloseWin<Win_MaterialEdit>(win_material_edit);
            CloseWin<Win_MaterialsDatabase>(win_material_db);
        }
        #endregion


    }
}
