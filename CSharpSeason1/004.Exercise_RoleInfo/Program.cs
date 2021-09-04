using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004.Exercise_RoleInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "sword";
            int hp = 100;
            int level = 34;
            float exp = 345.3f;
            Console.WriteLine("主角的名字是：{0}, \n血量：{1}， \n等级：{2}， \n经验：{3}", name, hp, level, exp);
            

            Console.ReadKey();

        }
    }
}
