using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005.Func
{
    class Program
    {
        Func<int, string> func1; //最后一个泛型是返回值

        static int Test1()
        {
            return 1;
        }

        static void Main(string[] args)
        {
            Func<int> a  = Test1;
            Console.WriteLine(a());

            Console.ReadKey();
        }
    }
}
