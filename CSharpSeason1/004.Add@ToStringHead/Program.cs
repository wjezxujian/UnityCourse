using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004.Add_ToStringHead
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I'm a good man. \n You are a bad girl.");
            Console.WriteLine(@"I'm a good man. \n You are a bad girl.");
            Console.WriteLine(@"I'm a good man. \n ""You"" 
                                are a bad girl.");

            Console.ReadKey();

        }
    }
}
