//#define IsTest

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _013.Features
{
    //命名参数
    [MyTest("简单的特性类", ID = 100)]
    class Program
    {
        [Obsolete("已弃用，使用NewMethod替换")]
        static void OldMethod()
        {
            Console.WriteLine("OldMethod");
        }

        static void NewMethod()
        {
            Console.WriteLine("NewMethod");
        }

        [Conditional("IsTest")]
        static void Test1()
        {
            Console.WriteLine("test1");
        }

        static void Test2()
        {
            Console.WriteLine("test2");
        }

        [DebuggerStepThrough] //跳过Debugger
        static void Test3()
        {
            Console.WriteLine("test3");
        }

        static void Main(string[] args)
        {
            OldMethod();

            Test1();
            Test2();
            Test1();
            Test3();

            PrintOut("123");

            Type type = typeof(Program);
            Object[] objects = type.GetCustomAttributes(false);
            foreach(var obj in objects)
            {
                var mytest = obj as MyTestAttribute;
                Console.WriteLine(mytest.Description);
            }

            Console.ReadKey();
        }

        static void PrintOut(string str, [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string methodName = "")
        {
            Console.WriteLine(str);
            Console.WriteLine(fileName);
            Console.WriteLine(lineNumber);
            Console.WriteLine(methodName);
            Console.ReadKey();
        }

    }
}
