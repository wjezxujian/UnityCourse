using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010.ObserverCat
{
    class Mouse
    {
        private string name;
        private string color;

        public Mouse(string name, string color, Cat cat)
        {
            this.name = name;
            this.color = color;
            cat.catCome += this.RunAway;
        }

        public void RunAway()
        {
            Console.WriteLine("{0}颜色的老鼠{1}说：猫来了，赶紧跑……", name, color);
        }
    }
}
