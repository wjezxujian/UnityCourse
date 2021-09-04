using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _017.ThreadTask
{
    class Program
    {
        static void ThreadMethod()
        {
            Console.WriteLine("任务开始." + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            Console.WriteLine("任务结束");
        }

        static void Main(string[] args)
        {
            //1.
            //Task t = new Task(ThreadMethod);
            //t.Start();

            //2.
            TaskFactory tf = new TaskFactory();
            Task t = tf.StartNew(ThreadMethod);
        }
    }
}
