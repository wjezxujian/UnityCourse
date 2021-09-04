using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008.Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> plus = (arg1, arg2) =>
            {
                return arg1 + arg2;
            };

            Console.WriteLine(plus(90, 60));

            //参数只有一个的时候可以不用括号,当函数体语句只有一句的时候可以不加上大括号，也可以不加上return
            Func<int, int> test2 = a => 23 + a;

            Console.WriteLine(test2(2));

            Console.ReadKey();
        }
                
    }
}
