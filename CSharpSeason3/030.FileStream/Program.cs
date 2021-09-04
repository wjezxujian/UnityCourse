using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace _030.FileStreamEx
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] date = new byte[1024];

            FileStream fileStream = new FileStream("TextFile1.txt", FileMode.OpenOrCreate);
            int length = 0;
            StringBuilder text = new StringBuilder();
            do
            {
                length = fileStream.Read(date, 0, 1024);
                text.Append(Encoding.UTF8.GetString(date, 0, length));
                Console.WriteLine(length);
            } while (length >= 1024);
            
            Console.WriteLine(text);

            FileStream fileStream2 = new FileStream("TextFile2.txt", FileMode.Create);
            byte[] date2 = Encoding.UTF8.GetBytes(text.ToString());
            fileStream2.Write(date2, 0, date2.Length);


            fileStream.Close();
            fileStream2.Close();
            Console.ReadKey();

        }
    }
}
