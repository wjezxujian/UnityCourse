using System;

namespace _001.DivideAndConquer
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] priceArray = { 100, 113, 110, 85, 105, 102, 86, 63, 81, 101, 94, 106, 101, 79, 94, 90, 97 };
            int[] priceFluctuateArray = new int[priceArray.Length - 1];

            for(int i = 1; i < priceArray.Length; ++i)
            {
                priceFluctuateArray[i - 1] = priceArray[i] - priceArray[i - 1];
            }

            for (int i = 0; i < priceFluctuateArray.Length; ++i)
            {
                Console.Write(i + ": " + priceFluctuateArray[i] + "    ");
            }

            for (int i = 0; i < priceFluctuateArray.Length; ++i)
            {
                Console.Write(i + ": " +priceFluctuateArray[i] + "    ");
            }

            Console.WriteLine();

            int total = 0;
            int minIndex = -1;
            int maxIndex = -1;
            for(int i = 0; i < priceFluctuateArray.Length; ++i)
            {
                var childTotal = 0;
                for(int j = i; j < priceFluctuateArray.Length; ++j)
                {
                    childTotal += priceFluctuateArray[j];
                    if(childTotal > total)
                    {
                        total = childTotal;
                        minIndex = i;
                        maxIndex = j;
                    }
                }
            }

            Console.WriteLine("最大数组和为：" + total);
            Console.WriteLine("最大数组起始索引为：" + minIndex + ", 结束索引为：" + maxIndex);



            Console.ReadKey();
        }
    }
}
