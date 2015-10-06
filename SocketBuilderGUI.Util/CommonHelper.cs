using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EthanYuWPFKit.Util
{
    public class CommonHelper
    {
        public static string ObjectToString(Object obj)
        {
            return (obj == null) ? string.Empty : obj.ToString();
        }



        public static int StringToInt(string str)
        {
            str = str.Trim();
            return (string.IsNullOrEmpty(str) ? 0 : int.Parse(str));
        }
        public static double StringToDouble(string str)
        {
            str = str.Trim();
            return (string.IsNullOrEmpty(str) ? 0 : double.Parse(str));
        }
    }
}
