
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010.ObserverCat
{
    class Cat
    {
        private string name;
        private string color;
        public event Action catCome; //声明一个事件,可以在外面注册，但是不能在外部触发

        public Cat(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        public void CatComming()
        {
            Console.WriteLine("{0}颜色的猫{1}过来了，喵喵喵……", name, color);

            if(catCome != null)
            {
                catCome();
            }            
        }

        

    }
}
