using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001.@string
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "www.swordxu.com"; //string 类型存储字符串
            int length = s.Length;

            if(s != "xxx")
            {
                Console.WriteLine("不相同");
            }

            Console.WriteLine(length);

            Console.ReadKey();
        }
    }
}
