using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009.Inherit
{
    class Enemy
    {
        private float hp;
        private float speed;

        public float HP
        {
            get { return hp; }

            set { hp = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public void AI()
        {
            Console.WriteLine("这里是Enemy1的公有AI方法");
        }

        public void Move()
        {
            Console.WriteLine("这里是Enemy1的公有Move方法");
        }
    }
}
