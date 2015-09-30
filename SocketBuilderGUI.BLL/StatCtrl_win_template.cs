using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


using EthanYuWPFKit.Util;
namespace EthanYuWPFKit.BLL
{
    public class StatCtrl_win_template:SingletonProvider<StatCtrl_win_template>, INotifyPropertyChanged
    {
        /// <summary>
        /// Region: INotifyPropertyChanged Implement
        /// </summary>
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


        /// <summary>
        /// Region: Binding vars related to disp control
        /// </summary>
        #region Binding vars related to disp control
        /// <summary>
        /// these attributes have get,set
        /// the set only implement ordinary set and notify property change
        /// </summary>
        string left_num_register;
        public string Left_num_register
        {
            get { return left_num_register; }
            set { left_num_register = value; Notify("Left_num_register"); }
        }
        #endregion


        /// <summary>
        /// Region: Binding vars related to db
        /// </summary>
        #region Binding vars related to db
        // New_user is only for input
        // it will not be modified once inputed unless a new input occurs
        // eg. public Users New_user;
        #endregion


        /// <summary>
        /// Region: Status vars
        /// </summary>
        #region Status vars
        /// <summary>
        /// these attributes have get, set
        /// the set implements the control of other variables
        /// it control the attributes in region disp
        /// for statis vars: use local value
        /// for binding vars: use public methods
        /// </summary>
        bool camera_opened;
        public bool Camera_opened
        {
            get { return camera_opened; }
            set
            {
                camera_opened = value;
            }
        }
        #endregion

        #region menber functions
        /// <summary>
        /// only init the status vars
        /// it will automatically init the binding vars
        /// 
        /// about priority
        /// the higher priority 
        /// the later the vars appear
        /// </summary>
        public StatCtrl_win_template() 
        {
            Camera_opened = false;
            //New_user = new Users();
            //New_user.Name = "zhangsan";
            //New_user.Job_no = "3";
        }
        #endregion





    }
}
