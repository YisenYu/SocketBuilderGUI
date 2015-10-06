using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.ComponentModel;
using EthanYuWPFKit.Util;
namespace Model
{
    public class PinCavInfo : INotifyPropertyChanged
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


        string pin_name;
        public string PinName
        {
            get { return pin_name; }
            set { pin_name = value; Notify("PinName"); }
        }
        string pin_type;
        public string PinType
        {
            get { return pin_type; }
            set { pin_type = value; Notify("PinType"); }
        }
        string pin_shape;
        public string PinShape
        {
            get { return pin_shape; }
            set { pin_shape = value; Notify("PinShape"); }
        }
        string pin_part_number;
        public string PinPartNumber
        {
            get { return pin_part_number; }
            set { pin_part_number = value; Notify("PinPartNumber"); }
        }
        int pin_cross_section;
        public int PinCrossSection
        {
            get { return pin_cross_section; }
            set { pin_cross_section = value; Notify("PinCrossSection"); }
        }


        string cav_name;
        public string CavName
        {
            get { return cav_name; }
            set { cav_name = value; Notify("CavName"); }
        }
        string cav_type;
        public string CavType
        {
            get { return cav_type; }
            set { cav_type = value; Notify("CavType"); }
        }
        string cav_shape;
        public string CavShape
        {
            get { return cav_shape; }
            set { cav_shape = value; Notify("CavShape"); }
        }
        string cav_part_number;
        public string CavPartNumber
        {
            get { return cav_part_number; }
            set { cav_part_number = value; Notify("CavPartNumber"); }
        }





        Dictionary<string, string> dict;
        public Dictionary<string, string> ToDictionary()
        {
            dict = new Dictionary<string, string>();
            dict.Add("PinName", pin_name);
            dict.Add("PinType", pin_type);
            dict.Add("PinShape", pin_shape);
            dict.Add("PinPartNumber", pin_part_number);
            dict.Add("PinCrossSection", pin_cross_section.ToString());

            dict.Add("CavName", cav_name);
            dict.Add("CavType", cav_type);
            dict.Add("CavShape", cav_shape);
            dict.Add("CavPartNumber", cav_part_number);
            return dict;
        }


        public static PinCavInfo ToObject(Dictionary<string, string> dict)
        {
            PinCavInfo obj = new PinCavInfo();
            if (dict.Keys.Count != 0)
            {
                obj.PinName = dict["PinName"];
                obj.PinType = dict["PinType"];
                obj.PinShape = dict["PinShape"];
                obj.PinPartNumber = dict["PinPartNumber"];
                obj.PinCrossSection = CommonHelper.StringToInt(dict["PinCrossSection"]);
                obj.CavName = dict["CavName"];
                obj.CavType = dict["CavType"];
                obj.CavShape = dict["CavShape"];
                obj.CavPartNumber = dict["CavPartNumber"];
            }
            return obj;
        }
    }
}
