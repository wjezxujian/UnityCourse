using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007.AnonymousFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> plus = delegate (int arg1, int arg2)
            {
                return arg1 + arg2;
            };

        }
    }
}
