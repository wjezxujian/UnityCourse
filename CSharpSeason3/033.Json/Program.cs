using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _033.Json
{
    class Program
    {
        static List<Skill> skills = new List<Skill>();

        static void Main(string[] args)
        {
            ////1.使用LitJson进行解析Json文本
            //JsonData jsonData = JsonMapper.ToObject(File.ReadAllText("json技能信息.json"));

            //foreach (JsonData temp in jsonData)
            //{
            //    JsonData idValue = temp["id"];
            //    JsonData nameValue = temp["name"];
            //    JsonData damageValue = temp["damage"];

            //    Skill skill = new Skill();
            //    skill.Id = Int32.Parse(idValue.ToString());
            //    skill.Name = nameValue.ToString();
            //    skill.Damage = Int32.Parse(damageValue.ToString());

            //    skills.Add(skill);
            //}

            ////2.使用数组去解析Json
            //Skill[] skills = JsonMapper.ToObject<Skill[]>(File.ReadAllText("json技能信息.json"));

            ////3.使用泛型去解析Json
            //List<Skill> skills = JsonMapper.ToObject<List<Skill>>(File.ReadAllText("json技能信息.json"));

            ////输出
            //foreach (Skill skill in skills)
            //{
            //    Console.WriteLine(skill);
            //}


            /////4.使用泛型实现复杂类型
            //Player player = JsonMapper.ToObject<Player>(File.ReadAllText("主角信息.json"));
            //Console.WriteLine(player);

            Player p = new Player();
            p.name = "花千骨";
            p.Level = 100;
            p.Age = 16;

            string json = JsonMapper.ToJson(p);
            Console.WriteLine(json);

            

            Console.ReadKey();
        }
    }
}

