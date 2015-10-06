using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using EthanYuWPFKit.Util;
namespace Model
{
    public class PinCavLibInfo : INotifyPropertyChanged
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




        string geometry_type;
        public string GeometryType
        {
            get { return geometry_type; }
            set { geometry_type = value; Notify("GeometryType"); }
        }
        string pin_material_name;
        public string PinMaterialName
        {
            get { return pin_material_name; }
            set { pin_material_name = value; Notify("PinMaterialName"); }
        }
        string pin_params;
        public string PinParams
        {
            get { return pin_params; }
            set { pin_params = value; Notify("PinParams"); }
        }
        string cav_params;
        public string CavParams
        {
            get { return cav_params; }
            set { cav_params = value; Notify("CavParams"); }
        }





        int pin_sections_num;
        public int PinSectionsNum
        {
            get { return pin_sections_num; }
            set { pin_sections_num = value; Notify("PinSectionsNum"); }
        }

        int cav_sections_num;
        public int CavSectionsNum
        {
            get { return cav_sections_num; }
            set { cav_sections_num = value; Notify("CavSectionsNum"); }
        }


        double pin_total_length;
        public double PinTotalLength
        {
            get { return pin_total_length; }
            set { pin_total_length = value; Notify("PinTotalLength"); }
        }
        double cav_total_length;
        public double CavTotalLength
        {
            get { return cav_total_length; }
            set { cav_total_length = value; Notify("CavTotalLength"); }
        }
        double pin_nominal_diameter;
        public double PinNominalDiameter
        {
            get { return pin_nominal_diameter; }
            set { pin_nominal_diameter = value; Notify("PinNominalDiameter"); }
        }
        double cav_nominal_diameter;
        public double CavNominalDiameter
        {
            get { return cav_nominal_diameter; }
            set { cav_nominal_diameter = value; Notify("CavNominalDiameter"); }
        }



        Dictionary<string, string> dict;
        public Dictionary<string, string> ToDictionary()
        {
            dict = new Dictionary<string, string>();
            dict.Add("GeometryType", geometry_type);
            dict.Add("PinMaterialName", pin_material_name);
            dict.Add("PinParams", pin_params);
            dict.Add("CavParams", cav_params);
            dict.Add("PinSectionsNum", pin_sections_num.ToString());
            dict.Add("CavSectionsNum", cav_sections_num.ToString());
            dict.Add("PinTotalLength", pin_total_length.ToString());
            dict.Add("CavTotalLength", cav_total_length.ToString());
            dict.Add("PinNominalDiameter", pin_nominal_diameter.ToString());
            dict.Add("CavNominalDiameter", cav_nominal_diameter.ToString());
            return dict;
        }

        public static PinCavLibInfo ToObject(Dictionary<string, string> dict)
        {
            PinCavLibInfo obj = new PinCavLibInfo();
            if (dict.Keys.Count != 0)
            {
                obj.GeometryType = dict["GeometryType"];
                obj.PinMaterialName = dict["PinMaterialName"];
                obj.PinParams = dict["PinParams"];
                obj.CavParams = dict["CavParams"];
                obj.PinSectionsNum = CommonHelper.StringToInt(dict["PinSectionsNum"]);
                obj.CavSectionsNum = CommonHelper.StringToInt(dict["CavSectionsNum"]);
                obj.PinTotalLength = CommonHelper.StringToDouble(dict["PinTotalLength"]);
                obj.CavTotalLength = CommonHelper.StringToDouble(dict["CavTotalLength"]);
                obj.PinNominalDiameter = CommonHelper.StringToDouble(dict["PinNominalDiameter"]);
                obj.CavNominalDiameter = CommonHelper.StringToDouble(dict["CavNominalDiameter"]);
            }
            return obj;
        }
    }
}
