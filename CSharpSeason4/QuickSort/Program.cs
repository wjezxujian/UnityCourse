using System;

namespace QuickSort
{
    class Program
    {
        static void QuickSort(int[] dataArray, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int baseValue = dataArray[left];
            int i = left;
            int j = right;

            while(true)
            {
                while (i < j)
                {
                    if (dataArray[j] <= baseValue)
                    {
                        dataArray[i] = dataArray[j];
                        break;
                    }
                    else
                    {
                        --j;
                    }
                }

                while (i < j)
                {
                    if (dataArray[i] > baseValue)
                    {
                        dataArray[j] = dataArray[i];
                        break;
                    }
                    else
                    {
                        ++i;
                    }
                }

                if(i == j)
                {
                    dataArray[i] = baseValue;
                    break;
                }
            }


            QuickSort(dataArray, left, i - 1);
            QuickSort(dataArray, i + 1, right);
        }


        static void Main(string[] args)
        {
            int[] data = new int[] { 8, 20, 17, 27, 13, 42, 17, 48 };
            QuickSort(data, 0, data.Length - 1);

            foreach (var temp in data)
            {
                Console.Write(temp + "  ");
            }

            Console.ReadKey();
        }
    }
}
