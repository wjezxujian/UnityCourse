using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009.Inherit
{
    class Program
    {
        static void Main(string[] args)
        {
            Boss boss = new Boss();

            //boss.AI();
            //boss.Move();
            boss.Attack();

            Console.ReadKey();

        }
    }
}
