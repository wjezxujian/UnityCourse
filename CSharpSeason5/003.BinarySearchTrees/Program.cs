using System;

namespace _003.BinarySearchTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] data = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

            BinaryTree<char> tree = new BinaryTree<char>();

            for(int i = 0; i < data.Length; ++i)
            {
                tree.Add(data[i]);
            }


            tree.FirstTraversal();
            tree.MidTraversal();
            tree.LastTraversal();
            tree.LayerTraversal();


            Console.ReadKey();
        }
    }
}
