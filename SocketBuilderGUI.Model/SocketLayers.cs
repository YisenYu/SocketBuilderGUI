using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using EthanYuWPFKit.Util;
namespace Model
{
    public class SocketLayers : INotifyPropertyChanged
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


        

        double layer_thickness;
        public double LayerThickness
        {
            get { return layer_thickness; }
            set { layer_thickness = value; Notify("LayerThickness"); }
        }
        string layer_material_name;
        public string LayerMaterialName
        {
            get { return layer_material_name; }
            set { layer_material_name = value; Notify("LayerMaterialName"); }
        }
        string layer_material_type;
        public string LayerMaterialType
        {
            get { return layer_material_type; }
            set { layer_material_type = value; Notify("LayerMaterialType"); }
        }


        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("LayerThickness", layer_thickness.ToString());
            dict.Add("LayerMaterialName", layer_material_name);
            dict.Add("LayerMaterialType", layer_material_type);
            return dict;
        }




        public static SocketLayers ToObject(Dictionary<string, string> dict)
        {
            
            SocketLayers obj = new SocketLayers();
            try
            {
                obj.LayerMaterialType = dict["LayerMaterialType"];
                obj.LayerMaterialName = dict["LayerMaterialName"];
                obj.LayerThickness = CommonHelper.StringToDouble(dict["LayerThickness"]);
            }
            catch { }
            return obj;
        }


    }
}
