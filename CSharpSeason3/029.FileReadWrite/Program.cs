using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029.FileReadWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            //读取文件全文
            string text =  File.ReadAllText("TextFile1.txt");
            Console.WriteLine(text);

            Console.WriteLine();
            Console.WriteLine();

            //读取文件到每一行
            string[] textLines = File.ReadAllLines("TextFile1.txt");
            foreach(string txt in textLines)
            {
                Console.WriteLine(txt);
            }
            

            Console.WriteLine();
            Console.WriteLine();

            //二进制读取
            byte[] byteArr = File.ReadAllBytes("TextFile1.txt");
            foreach (byte b in byteArr)
            {
                Console.Write(b);
            }

            //重写文件
            File.WriteAllText("TextFile2.txt", "swordxu,niubility!!!\n哈哈哈！！！");
            File.WriteAllLines("TextFile3.txt", new string[]{"123", "456", "789" });
            File.WriteAllBytes("TextFile4.txt", byteArr);



            Console.ReadKey();
        }
    }
}
