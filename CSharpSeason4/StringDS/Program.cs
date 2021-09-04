using System;

namespace StringDS
{
    class Program
    {
        static void Main(string[] args)
        {
            StringDS s = new StringDS("I am a teacher");
            StringDS i = new StringDS("excellent");
            StringDS r = new StringDS("student");

            Console.WriteLine(s.Length);
            Console.WriteLine(i.Length);
            Console.WriteLine(r.Length);

            StringDS s2 = s.SubString(7, 7);
            Console.WriteLine(s2);

            Console.WriteLine("TeaIndex:" + s.IndexOf(new StringDS("tea")));
            Console.WriteLine("CellIndex:" + i.IndexOf(new StringDS("cell")));
            Console.WriteLine("DenIndex:" + r.IndexOf(new StringDS("den")));

            Console.ReadKey();

            Array
        }
    }
}
