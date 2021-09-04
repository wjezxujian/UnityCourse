using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _014.Threading
{
    class Program
    {
        static int Test(int i, string str)
        {
            Console.WriteLine("test" + i + str);

            Thread.Sleep(100);

            return 100;
        }

        static void Main(string[] args)
        {
            //1.通过委托开启一个线程
            Func<int, string, int> a = Test;
            IAsyncResult ar =  a.BeginInvoke(100, "sword", OnCallBack, a); //开启新线程去指定a所引用的方法

            //while(ar.IsCompleted == false)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(10);
            //}

            //Console.WriteLine("");
            //Console.WriteLine(a.EndInvoke(ar));  //取得异步线程的返回值

            //bool isEnd = ar.AsyncWaitHandle.WaitOne(1000);  //阻塞1000毫秒等待线程结果
            //if (isEnd)
            //{
            //    Console.WriteLine(a.EndInvoke(ar));
            //}


            Console.WriteLine("main"); //异步执行
            Console.ReadKey();
        }

        static void OnCallBack(IAsyncResult ar)
        {
            Func<int, string, int> a = ar.AsyncState as Func<int, string, int>; 
            Console.WriteLine("子线程结束：" + a.EndInvoke(ar));
        }
    }
}
