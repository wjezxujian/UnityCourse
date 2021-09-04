using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _031.XmlEx
{
    class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lange { get; set; }
        public int Damage { get; set; }

        public override string ToString()
        {
            return String.Format("Id: {0},  Name: {1},  Lange: {2}, Damage: {3}", Id, Name, Lange, Damage);
        }
    }
}
