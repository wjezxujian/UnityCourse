using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _033.Json
{
    class Player
    {
        public string name;
        public int level;
        public int age;
        public List<Skill> skillList;

        public string Name { get { return name; } set { name = value; } }
        public int Level { get { return level; } set { level = value; } }
        public int Age { get { return age; } set { age = value; } }

        public List<Skill> SkillList { get { return skillList; } set { skillList = value; } }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder(string.Format("Name: {0}, Level: {1}, Age: {0}, SkillList:", Name, Level, Age));
            foreach (var skill in skillList)
            {
                message.Append("\n\t\t\t\t\t\t\t" + skill.ToString());
            }            

            return message.ToString();
        }
    }
}
