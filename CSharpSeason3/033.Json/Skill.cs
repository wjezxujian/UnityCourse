using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _033.Json
{
    class Skill
    {
        public int id;
        public string name;
        public int damage;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Damage { get { return damage; } set { damage = value; } }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Damage: {2}", Id, Name, Damage);
        }
    }
}
