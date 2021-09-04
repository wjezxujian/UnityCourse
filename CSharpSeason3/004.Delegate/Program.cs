using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004.Delegate
{
    class Program
    {
        delegate double TwoLongOp(long first, long second);
        private delegate string GetAString();
        private delegate void PrintString();

        Action action;

        Action<int> action2;

        Action<int, string> action3;

        Action<int, string, float> action4;

        static void Main(string[] args)
        {
            int x = 40;
            GetAString firstStringMethod = new GetAString(x.ToString);
            //firstStringMethod.Invoke();
            Console.WriteLine(firstStringMethod());

            Console.ReadKey();

        }

        static void PrintStr(PrintString print)
        {
            print();
        }
    }
}
