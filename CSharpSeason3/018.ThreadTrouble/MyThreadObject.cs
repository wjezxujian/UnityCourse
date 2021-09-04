using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _018.ThreadTrouble
{
    class MyThreadObject
    {
        private int state = 5;

        public void ChangeState()
        {
            lock (this)
            {
                state++;

                if (state == 5)
                {
                    Console.WriteLine("state == 5");
                }

                state = 5;
            }
            Console.WriteLine("Test");
        }
    }
}
