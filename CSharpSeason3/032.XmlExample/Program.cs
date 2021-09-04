using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _032.XmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Skill> skillList = new List<Skill>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("xml技能信息.xml");

            XmlNode skillInfoNode = xmlDoc.FirstChild;
            XmlNode skillListNode = skillInfoNode.FirstChild;

            XmlNodeList skillNodeList = skillListNode.ChildNodes;

            foreach(XmlNode skillNode in skillNodeList)
            {
                Skill skill = new Skill();
                XmlElement ele = skillNode["Name"];
                skill.Name = ele.InnerText;

                XmlAttributeCollection attributes = skillNode.Attributes;
                //foreach (XmlAttribute attr in attributes)
                //{
                //    if (attr.Name == "id")
                //    {
                //          skill.Id = Int32.Parse(attr.Value)
                //    }
                //}
                skill.Id = Int32.Parse(attributes["SkillID"].Value);
                skill.EngName = attributes["SkillEngName"].Value;
                skill.TriggerType = Int32.Parse(attributes["TriggerType"].Value);
                skill.ImageFile = attributes["ImageFile"].Value;
                skill.AvailableRace = Int32.Parse(attributes["AvailableRace"].Value);
                skillList.Add(skill);
            }

            foreach (Skill skill in skillList)
            {
                Console.WriteLine(skill);
            }

            Console.ReadKey();
        } 
    }
}
