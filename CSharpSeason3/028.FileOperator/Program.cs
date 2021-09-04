using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _028.FileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileInfo fileInfo = new FileInfo("../../TextFile1.txt");
            FileInfo fileInfo = new FileInfo("TextFile1.txt");
            //Console.WriteLine(fileInfo.Exists);
            if (fileInfo.Exists)
            {
                Console.WriteLine(fileInfo.Name);
                Console.WriteLine(fileInfo.Directory);
                Console.WriteLine(fileInfo.FullName);
                Console.WriteLine(fileInfo.Length);
                Console.WriteLine(fileInfo.IsReadOnly);
                Console.WriteLine(fileInfo.LastWriteTime);

                //fileInfo.Delete();                //删除
                //fileInfo.CopyTo("swordxu.text");  //拷贝
                //fileInfo.MoveTo("swordxu.txt");   //重命名
            }
            else
            {
                //fileInfo.Create();                //不存在，则创建
            }

            //文件夹操作
            DirectoryInfo dirInfo = new DirectoryInfo("./");
            Console.WriteLine(dirInfo.Exists);
            Console.WriteLine(dirInfo.Name);
            Console.WriteLine(dirInfo.FullName);
            Console.WriteLine(dirInfo.Parent);
            dirInfo.CreateSubdirectory("sowrdxu");
            var files = dirInfo.GetFiles();
            foreach(FileInfo file in files)
            {
                Console.WriteLine(file.Name);
            }

            var directories = dirInfo.GetDirectories();
            foreach (DirectoryInfo dir in directories)
            {
                Console.WriteLine(dir.Name);
            }



            Console.ReadKey();
        }
    }
}

