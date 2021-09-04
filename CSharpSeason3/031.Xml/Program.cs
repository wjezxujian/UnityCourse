using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _031.XmlEx
{
    class Program
    {
        static List<Skill> skillList = new List<Skill>();

        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("SkillInfo.xml");
            //xmlDoc.LoadXml(File.ReadAllText("SkillInfo.xml")); //解析字符串

            //得到根节点
            XmlNode rootNode = xmlDoc.FirstChild;

            //获取当前节点下面的所有子节点
            XmlNodeList skillNodeList = rootNode.ChildNodes;

            foreach (XmlNode skillNode in skillNodeList)
            {
                Skill skill = new Skill();
                XmlNodeList fieldNodes =  skillNode.ChildNodes;
                foreach (XmlNode fieldNode in fieldNodes)
                {
                    if (fieldNode.Name == "id")
                    {
                        int id = Int32.Parse(fieldNode.InnerText);
                        skill.Id = id;
                    }

                    if (fieldNode.Name == "name")
                    {
                        string name = fieldNode.InnerText;
                        skill.Name = name;
                        skill.Lange = fieldNode.Attributes[0].Value;
                    }

                    if (fieldNode.Name == "damage")
                    {
                        int damage = Int32.Parse(fieldNode.InnerText);
                        skill.Damage = damage;
                    }
                }

                skillList.Add(skill);
            }

            
            foreach(Skill skill in skillList)
            {
                Console.WriteLine(skill);
            }


            Console.ReadKey();

        }
    }
}
