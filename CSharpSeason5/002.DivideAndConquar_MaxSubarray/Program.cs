using System;

namespace _002.DivideAndConquar_MaxSubarray
{
    class Program
    {
        struct SubArray
        {
            public int startIndex;
            public int endIndex;
            public int total;
        }

        static void Main(string[] args)
        {
            int[] priceArray = { 100, 113, 110, 85, 105, 102, 86, 63, 81, 101, 94, 106, 101, 79, 94, 90, 97 };
            int[] priceFluctuateArray = new int[priceArray.Length - 1];

            for (int i = 1; i < priceArray.Length; ++i)
            {
                priceFluctuateArray[i - 1] = priceArray[i] - priceArray[i - 1];
            }

            for (int i = 0; i < priceFluctuateArray.Length; ++i)
            {
                Console.Write(i + ": " + priceFluctuateArray[i] + "    ");
            }
            Console.WriteLine();

            SubArray maxArray = GetMaxSubArray(priceFluctuateArray, 0, priceFluctuateArray.Length - 1);
            Console.WriteLine("最大数组和为：" + maxArray.total);
            Console.WriteLine("最大数组起始索引为：" + maxArray.startIndex + ", 结束索引为：" + maxArray.endIndex);

            Console.ReadKey();
        }

        static SubArray GetMaxSubArray(int[] array, int low, int high)
        {
            if(low == high)
            {
                SubArray subarray;
                subarray.total = array[low];
                subarray.startIndex = low;
                subarray.endIndex = high;
                return subarray;
            }


            int mid = (low + high) / 2;
            SubArray lowSubArray = GetMaxSubArray(array, low, mid);
            SubArray highSubArray = GetMaxSubArray(array, mid + 1, high);

            SubArray midLeftSubArray;
            midLeftSubArray.total = 0;
            midLeftSubArray.startIndex = mid;

            int totalTemp = 0;
            for(int i = mid; i >=low; --i)
            {
                totalTemp += array[i];
                if(totalTemp > midLeftSubArray.total)
                {
                    midLeftSubArray.total = totalTemp;
                    midLeftSubArray.startIndex = i;
                }
            }

            SubArray midRightSubArray;
            midRightSubArray.total = 0;
            midRightSubArray.endIndex = mid + 1;
            totalTemp = 0;
            for (int i = mid + 1; i < high; ++i)
            {
                totalTemp += array[i];
                if (totalTemp > midRightSubArray.total)
                {
                    midRightSubArray.total = totalTemp;
                    midRightSubArray.endIndex = i;
                }
            }

            SubArray midSubArray;
            midSubArray.total = midLeftSubArray.total + midRightSubArray.total;
            midSubArray.startIndex = midLeftSubArray.startIndex;
            midSubArray.endIndex = midRightSubArray.endIndex;

            return lowSubArray.total >= highSubArray.total ? lowSubArray.total >= midSubArray.total ? lowSubArray : midSubArray
                : highSubArray.total >= midSubArray.total ? highSubArray : midSubArray;
        }
    }
}
