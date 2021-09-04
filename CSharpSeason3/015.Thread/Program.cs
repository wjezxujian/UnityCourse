using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _015.ThreadEx
{
    class Program
    {
        static void Download(object filename)
        {
            Console.WriteLine("开始下载:" + filename + ", "+ Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("下载完成");
        }

        static void Main(string[] args)
        {
            //1.
            //new Thread(() =>
            //{
            //    Console.WriteLine("开始下载:" + Thread.CurrentThread.ManagedThreadId);
            //    Thread.Sleep(2000);
            //    Console.WriteLine("下载完成");
            //}).Start();

            //Console.WriteLine("Main: " + Thread.CurrentThread.ManagedThreadId);

            //2.传递数据
            //Thread t = new Thread(Download);
            //t.Start("xxx.种子");

            //Console.WriteLine("Main: " + Thread.CurrentThread.ManagedThreadId);

            //3.传递成员方法而不仅是静态方法
            //MyThread my = new MyThread("sword.niu", "http://www.swrodxu.com/");
            //new Thread(my.Download).Start();
            //Console.WriteLine("Main: " + Thread.CurrentThread.ManagedThreadId);

            //4.前台线程
            Thread t = new Thread(Download);
            //t.IsBackground = true; //后台线程
            t.Start("xxx");

            //5.Running Unstarted状态 Thread.Sleep方法进入WaitSleepJoin状态，Abort终止进程 可以使用try catch 捕获进程
            //try { t.Abort(); } catch { Console.WriteLine("结束线程"); }
            //t.Join(); //WaitSleepJoin

            //Console.ReadKey();
            


        }
    }
}
