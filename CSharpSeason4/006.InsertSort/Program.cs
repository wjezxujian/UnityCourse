using System;

namespace _006.InsertSortEx
{
    class Program
    {
        static void InsertSort(int[] dataArray)
        {
            for(int i = 1; i < dataArray.Length; ++i)
            {
                int iValue = dataArray[i];

                int j = i;
                for(; j > 0; --j)
                {
                    if(iValue < dataArray[j - 1])
                    {
                        dataArray[j] = dataArray[j - 1];
                    }
                    else
                    {
                        break;
                    }
                }

                dataArray[j] = iValue;
            }
        }


        static void Main(string[] args)
        {
            int[] data = new int[] { 42, 20, 17, 27, 13, 8, 17, 48 };
            InsertSort(data);

            foreach(var temp in data)
            {
                Console.Write(temp + "  ");
            }

            Console.ReadKey();
        }
    }
}
