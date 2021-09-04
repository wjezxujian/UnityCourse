using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _018.ThreadTrouble
{
    class Program
    {
        static void ChangeState(object o)
        {
            var my = o as MyThreadObject;
            while (true)
            {
                my.ChangeState();
            }
            
        }

        static void Main(string[] args)
        {
            MyThreadObject myThread = new MyThreadObject();
            Thread t = new Thread(ChangeState);
            t.Start(myThread);

            Thread t2 = new Thread(ChangeState);
            t2.Start(myThread);



        }
    }
}
