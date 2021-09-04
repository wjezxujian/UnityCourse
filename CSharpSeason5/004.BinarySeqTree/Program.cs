using System;

namespace _004.BinarySortTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySortTree<int> tree = new BinarySortTree<int>();

            //int[] data = { 62, 58, 88, 47, 73, 99, 35, 51, 93, 37 };
            int[] data = { 62, 88, 58, 99, 73, 47, 93, 35, 51, 37 };

            for (int i = 0; i < data.Length; ++i)
            {
                tree.Add(data[i]);
            }

            Console.WriteLine("Find 99: " + tree.Find(99));
            Console.WriteLine("Find 100: " + tree.Find(100));

            Console.ReadKey();
        }
    }
}
