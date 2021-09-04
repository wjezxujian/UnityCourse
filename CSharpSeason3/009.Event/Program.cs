using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009.Event
{
    class Program
    {
        public delegate void MyDelegate();
        //public MyDelegate myDelegate;
        public event MyDelegate myDelegateEvent;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.myDelegate = Test1;

            p.myDelegate();

            Console.ReadKey();
        }

        static void Test1()
        {
            Console.WriteLine("test1");
        }
    }
}
