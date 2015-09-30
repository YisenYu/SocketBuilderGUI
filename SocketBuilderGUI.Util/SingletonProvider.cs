using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EthanYuWPFKit.Util
{
    /*
     * class
     * singleton provider
     */ 
    public class SingletonProvider<T> where T : new()
    {
        protected SingletonProvider()  
        {  
            if (Instance != null)  
            {  
                throw (new Exception("You have tried to create a new singleton class where you should have instanced it. Replace your \"new class()\" with \"class.Instance\""));  
            }  
        }





        public static T Instance
        {
            get 
            { 
                return SingletonCreator.instance; 
            }
        }


        class SingletonCreator
        {
            static SingletonCreator() { }
            internal static readonly T instance = new T();
        }


        public void Init() { }
    }


    /*
     * class
     * test class for singletonprovider
     */ 
    //public class TestSingletonProvider : SingletonProvider<TestSingletonProvider>
    //{
    //    public TestSingletonProvider() { }

    //    //call the function inside
    //    //TestSingletonProvider.Instance.TestFunction();  
    //    public void TestFunction()
    //    {
    //        MessageBox.Show("test!","test",MessageBoxButton.YesNoCancel);
    //    }
    //}


}
