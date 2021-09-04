using System;

namespace SelectSort
{
    class Program
    {

        static void SelectSort(int[] dataArray)
        {
            for(int i = 0; i < dataArray.Length - 1; ++i)
            {
                int mixValue = dataArray[i];
                int mixIndex = i;
                for(int j = i + 1; j < dataArray.Length; ++j)
                {
                    if(mixValue > dataArray[j])
                    {
                        mixValue = dataArray[j];
                        mixIndex = j;
                    }
                }

                dataArray[mixIndex] = dataArray[i];
                dataArray[i] = mixValue;
            }
        }
        static void Main(string[] args)
        {
            int[] data = new int[] { 42, 20, 17, 27, 13, 8, 17, 48 };
            SelectSort(data);

            foreach (var temp in data)
            {
                Console.Write(temp + "  ");
            }

            Console.ReadKey();
        }
    }
}
