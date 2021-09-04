using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _031.StreamReaderAndStreamWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("TextFile1.txt");

            //int length = 0;
            //do
            //{
            //    string strLine = reader.ReadLine();
            //    length = strLine == null ? 0 : 1;
            //    Console.WriteLine(strLine);
            //} while (length > 0) ;

            //int index = 0;
            //do
            //{
            //    char[] data = new char[1024];
            //    index = reader.Read(data, 0, 1024);
            //    Console.Write(data);
            //} while (index != 0);
            //Console.WriteLine();

            string text = reader.ReadToEnd();
            Console.WriteLine(text);

            StreamWriter writer = new StreamWriter("TextFile2.txt");
            writer.Write(text);

            StreamWriter writer2 = new StreamWriter("TextFile3.txt");
            while (true)
            {
                string message = Console.ReadLine();
                if(message == "quit;")
                {
                    break;
                }
                writer2.Write(message + "\n");
            }
            


            reader.Close();
            writer.Close();
            writer2.Close();

            Console.ReadKey();

        }
    }
}
