using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011.LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化武林高手
            var masterList = new List<MartialArtsMaster>(){
                new MartialArtsMaster(){ Id = 1, Name = "黄蓉",    Age = 18, Menpai = "丐帮", Kongfu = "打狗棒法",  Level = 9  },
                new MartialArtsMaster(){ Id = 2, Name = "洪七公",  Age = 70, Menpai = "丐帮", Kongfu = "打狗棒法",  Level = 10 },
                new MartialArtsMaster(){ Id = 3, Name = "郭靖",    Age = 22, Menpai = "丐帮", Kongfu = "降龙十八掌",Level = 10 },
                new MartialArtsMaster(){ Id = 4, Name = "任我行",  Age = 50, Menpai = "明教", Kongfu = "葵花宝典",  Level = 1  },
                new MartialArtsMaster(){ Id = 5, Name = "东方不败",Age = 35, Menpai = "明教", Kongfu = "葵花宝典",  Level = 10 },
                new MartialArtsMaster(){ Id = 6, Name = "林平之",  Age = 23, Menpai = "华山", Kongfu = "葵花宝典",  Level = 7  },
                new MartialArtsMaster(){ Id = 7, Name = "岳不群",  Age = 50, Menpai = "华山", Kongfu = "葵花宝典",  Level = 8  },
                new MartialArtsMaster() { Id = 8, Name = "令狐冲", Age = 23, Menpai = "华山", Kongfu = "独孤九剑", Level = 10 },
                new MartialArtsMaster() { Id = 9, Name = "梅超风", Age = 23, Menpai = "桃花岛", Kongfu = "九阴真经", Level = 8 },
                new MartialArtsMaster() { Id =10, Name = "黄药师", Age = 23, Menpai = "梅花岛", Kongfu = "弹指神通", Level = 10 },
                new MartialArtsMaster() { Id = 11, Name = "风清扬", Age = 23, Menpai = "华山", Kongfu = "独孤九剑", Level = 10 }
            };

            //初始化武学
            var kongfuList = new List<Kongfu>(){
                new Kongfu(){Id=1, Name="打狗棒法", Power=90},
                new Kongfu(){Id=2, Name="降龙十八掌", Power=95},
                new Kongfu(){Id=3, Name="葵花宝典", Power=100},
                new Kongfu() { Id=  4, Name = "独孤九剑", Power = 100 },
                new Kongfu() { Id = 5, Name = "九阴真经", Power = 100 },
                new Kongfu() { Id = 6, Name = "弹指神通", Power = 100 }
            };

            //使用LINQ查询
            var res = from m in masterList where m.Level > 8 || m.Level == 8 select m;
            res.ToList().ForEach(m => Console.WriteLine(m));

            Console.WriteLine("");

            masterList.Where(m => m.Level >= 8).ToList().ForEach(m => Console.WriteLine(m));

            Console.WriteLine("");

            //使用LINQ联合查询
            var res2 = from m in masterList from k in kongfuList where m.Kongfu == k.Name select new { master = m, kongfu = k};
            res2.ToList().ForEach(m => Console.WriteLine(m));
            Console.WriteLine("");

            masterList.SelectMany(_ => kongfuList, (m, k) => new { master = m, kongfu = k }).Where(m => m.master.Kongfu == m.kongfu.Name)
                .ToList().ForEach(m => Console.WriteLine(m));

            Console.WriteLine("");

            //对查询结构做排序
            var res3 = from m in masterList from k in kongfuList where m.Kongfu == k.Name orderby m.Age descending select new { master = m, kongfu = k };
            res3.ToList().ForEach(m => Console.WriteLine(m));
            Console.WriteLine("");

            masterList.SelectMany(_ => kongfuList, (m, k) => new { master = m, kongfu = k }).Where(m => m.master.Kongfu == m.kongfu.Name).OrderByDescending(m => m.master.Age).ThenBy(m => m.master.Level)
              .ToList().ForEach(m => Console.WriteLine(m));
            Console.WriteLine("");

            //join on 集合联合
            var res4 = from m in masterList join k in kongfuList on m.Kongfu equals k.Name select new { master = m, kongfu = k };
            res4.ToList().ForEach(m => Console.WriteLine(m));
            Console.WriteLine("");

            //分组查询 into groups
            var res5 = from k in kongfuList join m in masterList on k.Name equals m.Kongfu into groups orderby  groups.Count() descending select new { kongfu = k, count = groups.Count()};
            res5.ToList().ForEach(m => Console.WriteLine(m));
            Console.WriteLine("");

            //按照自身字段分组
            var res6 = from m in masterList group m by m.Menpai into g select new { count = g.Count(), menpai = g.Key };
            res6.ToList().ForEach(m => Console.WriteLine(m));
            Console.WriteLine("");

            //量词操作符 any all 
            bool isAny = masterList.Any(m => m.Menpai == "丐帮");
            Console.WriteLine(isAny);

            bool isAll = masterList.All(m => m.Menpai == "丐帮");
            Console.WriteLine(isAll);


            Console.ReadKey();
        }
    }
}
