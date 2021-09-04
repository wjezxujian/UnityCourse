using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _002.StringBuilderEX
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.
            StringBuilder sb = new StringBuilder("www.swordxu.com");

            //2.
            StringBuilder sb2 = new StringBuilder(20);

            StringBuilder sb3 = new StringBuilder("www.swordxu.com", 100);
            sb3.Append("/xxx.html");
            Console.WriteLine(sb3.ToString());

            sb3.Insert(0, "http://");
            Console.WriteLine(sb3.ToString());

            sb3.Replace("http://", "https://");
            Console.WriteLine(sb3.ToString());



            Console.ReadKey();


        }
    }
}
