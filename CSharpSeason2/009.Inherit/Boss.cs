using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009.Inherit
{
    class Boss : Enemy
    {
        public void Attack()
        {
            AI();
            Move();
            HP = 100;
            //hp = 100;

            Console.WriteLine("Boss正在进行攻击");
        }

    }
}
