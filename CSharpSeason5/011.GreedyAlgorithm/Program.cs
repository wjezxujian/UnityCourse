using System;

namespace _011.GreedyAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] counts = { 3, 0, 2, 1, 0, 3, 5 };
            int[] values = { 1, 2, 5, 10, 20, 50, 100};

            int[] result = Pay(320, counts, values);

            foreach (int temp in result)
            {
                Console.Write(temp + "  ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }

        static int[] Pay(int k, int[] counts, int[] values)
        {
            int[] result = new int[values.Length + 1];

            for (int i = values.Length - 1; k > 0 || i >= 0; --i)
            {
                if(k / values[i] > counts[i])
                {
                    result[i] = counts[i];
                    k -= values[i] * counts[i];
                }
                else
                {
                    result[i] = k / values[i];
                    k -= result[i] * values[i];
                }
            }

            result[result.Length - 1] = k;

            return result;
        }
    }
}
