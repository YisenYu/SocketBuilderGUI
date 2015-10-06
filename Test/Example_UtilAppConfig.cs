using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using EthanYuWPFKit.Util;
namespace Test
{



    public class TestClass
    {
        public string Type;

        public static bool IsDictEmpty(Dictionary<string, string> dict)
        {
            if (dict.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




    }
    class Program
    {
        static string a;
        static void Main(string[] args)
        {
            //UtilAppConfig_Ini tool = new UtilAppConfig_Ini("test.ini");

            //tool.AddKey("name1", "yyss3", "section2");
            //tool.AddKey("name2", "张三4", "section2");


            //tool.AddKey("name1", "yyss3", "studentsinfo");
            //tool.AddKey("name2", "张三4", "studentsinfo");
            //tool.SetValue("name3", "zhangsan5", "studentsinfo");
            //string res = tool.GetValue("name1", "studentsinfo");
            //string[] resm = tool.GetAllKeys("studentsinfo");
            //foreach (string item in resm)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(resm.Length);


            //Dictionary<string, string> mydict = new Dictionary<string, string>();
            //mydict.Add("name", "zhangsan");
            //mydict.Add("age", "18");

            //Dictionary<string, Dictionary<string, string>> mydictlist =
            //    new Dictionary<string, Dictionary<string, string>>();
            //mydictlist.Add("1", mydict);



            //Guid id = new Guid("0a9dce00-9fe4-44cc-a881-59102a1273fd");

            //Console.WriteLine(id.ToString());


            //List<int> a = new List<int> { 1, 2, 3 };
            //List<int> b = new List<int> { 3, 4, 5 };
            //b = a;
            //Console.WriteLine(string.Join(",",b));
            //List<int> r = a.Union(b).ToList<int>();

            //int num = 8;
            //List<string> list = new List<string>(num);
            //for (int i = 0; i < num; i++ )
            //{
            //    list[i] = i.ToString();
            //}

            //Dictionary<string, string> dict = new Dictionary<string, string>();
            //int i = dict.Keys.Count;
            //string str = dict.Keys.Count.ToString();
            string a = "";
            int i = int.Parse(a);

            Console.WriteLine(i.ToString());
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
