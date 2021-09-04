using System;
using System.Collections.Generic;

namespace _009.GreedyAlgorithm_Recursive
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] s = {0, 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 1};
            int[] e = {0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};

            List<int> tempList = RecursiveActivitySelect(0, s, e);

            foreach (int temp in tempList)
            {
                Console.Write(temp + "  ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }

        static List<int> RecursiveActivitySelect(int start, int[] s, int[] e){
            if(start > s.Length - 1)
            {
                return new List<int>();
            }

            int tempIndex = 0;
            for (int i = start + 1; i < s.Length; ++i)
            {
                if (s[i] >= e[start])
                {
                    tempIndex = i;
                    break;
                }
            }

            if (tempIndex > 0)
            {
                List<int> list = RecursiveActivitySelect(tempIndex + 1, s, e);
                list.Add(tempIndex);
                return list;
            }
            else
            {
                return new List<int>();
            }
        }
    }
}
