using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using EthanYuWPFKit.Util;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            UtilAppConfig_Ini tool = new UtilAppConfig_Ini("test.ini");

            tool.AddKey("name1", "yyss3", "section2");
            tool.AddKey("name2", "张三4", "section2");


            tool.AddKey("name1", "yyss3", "studentsinfo");
            tool.AddKey("name2", "张三4", "studentsinfo");
            tool.SetValue("name3", "zhangsan5", "studentsinfo");
            string res = tool.GetValue("name1", "studentsinfo");
            string[] resm = tool.GetAllKeys("studentsinfo");
            foreach (string item in resm)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(resm.Length);

            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
