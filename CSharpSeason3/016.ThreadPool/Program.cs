using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _016.ThreadPoolEx
{
    class Program
    {
        static void ThreadMethod(object state)
        {
            Console.WriteLine("线程开始." + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("线程结束");
        }

        static void Main(string[] args)
        {
            //开启多个工作后台线程，不能修改成前台线程，优先级，名字
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);


            Console.ReadKey();
        }
    }
}
