using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001.LinearList
{
    class Program
    {
        static void Main(string[] args)
        {
            ////1.使用BCL中的List线性表
            //List<string> strList = new List<string>();
            //strList.Add("123");
            //strList.Add("456");
            //strList.Add("789");
            //Console.WriteLine(strList[1]);
            //strList.Remove("789");
            //Console.WriteLine(strList.Count);
            //strList.Clear();

            //Console.ReadKey();

            ////2.使用自定义顺序表
            //SeqList<string> seqList = new SeqList<string>();
            //seqList.Add("123");
            //seqList.Add("456");
            //seqList.Add("789");

            //Console.WriteLine(seqList.GetEle(0));
            //Console.WriteLine(seqList[0]);
            //seqList.Insert("777", 1);

            //for(int i = 0; i < seqList.GetLength(); ++i)
            //{
            //    Console.Write(seqList[i] + "\t");
            //}

            //Console.WriteLine();
            //seqList.Delete(0);
            //for (int i = 0; i < seqList.GetLength(); ++i)
            //{
            //    Console.Write(seqList[i] + "\t");
            //}

            //Console.WriteLine();

            //seqList.Clear();
            //Console.WriteLine("Count:" + seqList.GetLength());

            //Console.ReadKey();

            //3.使用自定义链表
            LinkList<string> linkList = new LinkList<string>();
            linkList.Add("123");
            linkList.Add("456");
            linkList.Add("789");
            Console.WriteLine(linkList.GetEle(1));
            Console.WriteLine(linkList[1]);
            linkList.Insert("777", 1);
            for (int i = 0; i < linkList.GetLength(); ++i)
            {
                Console.Write(linkList[i] + "\t");
            }
            Console.WriteLine();

            linkList.Delete(0);
            for (int i = 0; i < linkList.GetLength(); ++i)
            {
                Console.Write(linkList[i] + "\t");
            }
            Console.WriteLine();

            linkList.Delete(2);
            for (int i = 0; i < linkList.GetLength(); ++i)
            {
                Console.Write(linkList[i] + "\t");
            }
            Console.WriteLine();

            linkList.Add("888");
            linkList.Add("999");

            linkList.Delete(2);

            Console.WriteLine("Locate: " + linkList.Locate("999"));

            linkList.Clear();
            Console.WriteLine("Count: " + linkList.GetLength());

            Console.ReadKey();

        }
    }
}
