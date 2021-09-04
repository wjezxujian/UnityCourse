using System;
using System.Collections.Generic;
using System.Linq;

namespace _008.DynamicProgramming_Select
{
    class Program
    {


        static void Main(string[] args)
        {
            int[] s = { 0, 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12, 24 };
            int[] e = { 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 24 };

            List<int>[,] result = new List<int>[13, 13] ;
            for(int i = 0; i < result.GetLength(0); ++i)
            {
                for(int j = 0; j < result.GetLength(1); ++j)
                {
                    result[i, j] = new List<int>();
                }
            }

            for (int j = 0; j < 13; ++j)
            { 
                for (int i = 0; i < j - 1; ++i)
                {
                    //考虑s[ij] i结束之后 j开始之前，活动集合存不存在
                    //e[i] s[j] 这个时间之内的所有活动
                    List<int> sij = new List<int>();
                    for(int number = 1; number < s.Length - 1; ++number)
                    {
                        if (s[number] >= e[i] && e[number] <= s[j])
                        {
                            sij.Add(number);
                        }
                    }

                    if (sij.Count > 0)
                    {
                        //result[i,] = max(result[i, k] + result[k, j] + k}

                        int maxCount = 0;
                        List<int> tempList = new List<int>();
                        foreach (int number in sij)
                        {
                            int count = result[i, number].Count + result[number, j].Count + 1;
                            if (maxCount < count)
                            {
                                maxCount = count;
                                tempList = result[i, number].Union(result[number, j]).ToList();
                                tempList.Add(number);
                            }
                        }

                        result[i, j] = tempList;
                    }
                }
            }

            foreach (int temp in result[0, 12])
            {
                Console.WriteLine(temp);
            }
            

            Console.ReadKey();
        }
    }
}
