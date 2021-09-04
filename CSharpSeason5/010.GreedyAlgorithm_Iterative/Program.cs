using System;
using System.Collections.Generic;

namespace _010.GreedyAlgorithm_Iterative
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] s = { 0, 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 };
            int[] e = { 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            List<int> tempList = IterativeActivitySelect(s, e);

            foreach (int temp in tempList)
            {
                Console.Write(temp + "  ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }

        static List<int> IterativeActivitySelect(int[] s, int[] e)
        {
            int k = 0;
            List<int> tempList = new List<int>();
            for(int m = k + 1; m < s.Length; ++m)
            {
                if(s[m] >= e[k])
                {
                    tempList.Add(m);
                    k = m;
                }
            }

            return tempList;
        }
    }
}
