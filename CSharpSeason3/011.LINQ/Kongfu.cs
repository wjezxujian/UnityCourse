using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011.LINQ
{
    class Kongfu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Power: {2}", Id, Name, Power);
        }
    }
}
