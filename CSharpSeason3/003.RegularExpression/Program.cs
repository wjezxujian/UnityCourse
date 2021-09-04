using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _003.RegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "I am blue cat.";

            string res = Regex.Replace(s, "^", "开始：");

            Console.WriteLine(res);

            string res2 = Regex.Replace(s, "$", "结束");

            Console.WriteLine(res2);

            string s2 = Console.ReadLine();

            string des2 = Regex.IsMatch(s2, @"^\d+$") ? "是数字" : "不是数字";
            Console.WriteLine(des2);

            string s3 = Console.ReadLine();
            string des3 = Regex.IsMatch(s3, @"^\W+$") ? "是" : "不是";
            Console.WriteLine("是否为除w之外的任何字符: " + des3);

            string s4 = "34((*&sdflkh路口设计费";
            string pattern = @"\d|[a-z]";
            MatchCollection col = Regex.Matches(s4, pattern);
            foreach (Match match in col)
            {
                Console.WriteLine(match.ToString());
            }

            string s5 = "zhangsan;lisi,wangwu.zhaoliu";
            string pattern2 = @"[;,.]";
            string[] resArray = Regex.Split(s5, pattern2);
            foreach(string name in resArray)
            {



                Console.WriteLine(name);
            }



            Console.ReadKey();
        }
    }

}
