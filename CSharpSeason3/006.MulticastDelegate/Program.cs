using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006.MulticastDelegate
{
    //多播委托是按照添加顺序调用，只能拿到最后一个方法的返回值，一般来说返回值声明为空
    class Program
    {
        static void Test1()
        {
            Console.WriteLine("test1");
            //throw new Exception();
        }

        static void Test2()
        {
            Console.WriteLine("test2");
        }



        static void Main(string[] args)
        {
            Action a = Test1;
            a += Test2;
            a();

            Delegate[] delegates = a.GetInvocationList();

            foreach(var ac in delegates)
            {
                ac.DynamicInvoke();
            }

            a -= Test1;
            a();

            a -= Test2;
            if(a != null) a();

            Console.ReadKey();

        }
    }
}
