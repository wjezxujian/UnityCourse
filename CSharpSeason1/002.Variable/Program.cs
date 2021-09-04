using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002.Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 20;
            int hp = 60;
            string name = "sword";

            Console.WriteLine("name: {2}, age: {0}, hp: {1}", age, hp, name);

            Console.ReadKey();
        }
    }
}
