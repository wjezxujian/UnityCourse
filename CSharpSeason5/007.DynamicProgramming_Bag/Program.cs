using System;

namespace _007.DynamicProgramming_Bag
{
    struct Status
    {
        public bool isCalc;
        public int value;
    }

    class Program
    {
        static Status[,] result = new Status[11, 4];
        static int[] weights = {0, 3, 4, 5 };
        static int[] prices = {0, 4, 5, 6 };


        static void Main(string[] args)
        {
            ResetArray(result);

            var startTime = DateTime.Now;

            Console.WriteLine(UpDown(10, 3));
            Console.WriteLine(UpDown(3, 3));
            Console.WriteLine(UpDown(4, 3));
            Console.WriteLine(UpDown(5, 3));
            Console.WriteLine(UpDown(7, 3));

            Console.WriteLine(DateTime.Now - startTime);
            Console.WriteLine();
            ResetArray(result);
            startTime = DateTime.Now;

            Console.WriteLine(DownUp(10, 3));
            Console.WriteLine(DownUp(3, 3));
            Console.WriteLine(DownUp(4, 3));
            Console.WriteLine(DownUp(5, 3));
            Console.WriteLine(DownUp(7, 3));

            Console.WriteLine(DateTime.Now - startTime);


            Console.ReadKey();
        }

        //capacity是背包容量，i是物品序号索引，返回值是m可以存储的最大价值
        static public int UpDown(int capacity, int i)
        {
            if (i <= 0 || capacity <= 0) return 0;
            if (result[capacity, i].isCalc) return result[capacity, i].value;

            if (weights[i] > capacity)
            {
                result[capacity, i].isCalc = true;
                result[capacity, i].value = UpDown(capacity, i - 1);
                return result[capacity, i].value;
            }
            else
            {
                int putValue = UpDown(capacity - weights[i], i - 1) + prices[i];
                int noputValue = UpDown(capacity, i - 1);

                result[capacity, i].isCalc = true;
                result[capacity, i].value = putValue > noputValue ? putValue : noputValue;

                return result[capacity, i].value;
            }
        }

        static public int DownUp(int capacity, int i)
        {
            if (i <= 0 || capacity <= 0) return 0;
            if (result[capacity, i].isCalc) return result[capacity, i].value;

            for (int tempM = 1; tempM <= capacity; ++tempM)
            {
                for (int tempI = 1; tempI <= i; ++tempI)
                {
                    if (result[tempM, tempI].isCalc) continue;

                    if (weights[tempI] > tempM)
                    {
                        result[tempM, tempI].isCalc = true;
                        result[tempM, tempI].value = result[tempM, tempI - 1].value;
                    }
                    else
                    {             
                        int putValue = result[tempM - weights[tempI], tempI - 1].value + prices[tempI];
                        int noputValue = result[tempM, tempI - 1].value;
                        result[tempM, tempI].isCalc = true;
                        result[tempM, tempI].value = putValue > noputValue ? putValue : noputValue;
                    }
                }
            }

            return result[capacity, i].value;
        }

        static void ResetArray(Status[,] data)
        {
            for (int i = 0; i < data.GetLength(0); ++i)
            {
                for (int j = 0; j < data.GetLength(1); ++j)
                {
                    data[i, j].isCalc = false;
                    data[i, j].value = 0;
                }
            }

            data[0, 0].isCalc = true;
        }
    }
}
