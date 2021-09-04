using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003.BinarySearchTrees
{
    class BinaryTree<T>
    {
        private T[] data;
        private int count;

        public BinaryTree(int capicity = 0)
        {
            capicity = capicity <= 0 ? 16 : capicity;
            data = new T[capicity];
            count = 0;
        }

        public bool Add(T item)
        {
            if(count < data.Length)
            {
                data[count] = item;
                ++count;
                return true;
            }

            return false;
        }

        public void FirstTraversal()
        {
            FirstTraversal(0);
            Console.WriteLine();
        }

        public void MidTraversal()
        {
            MidTraversal(0);
            Console.WriteLine();
        }

        public void LastTraversal()
        {
            LastTraversal(0);
            Console.WriteLine();
        }

        private void FirstTraversal(int index)
        {
            if(index > count - 1)
            {
                return;
            }

            int number = index + 1;

            Console.Write(data[index] + "   ");

            int leftNumber = number * 2;
            int rightNumber = leftNumber + 1;

            FirstTraversal(leftNumber - 1);
            FirstTraversal(rightNumber - 1);
        }

        private void MidTraversal(int index)
        {
            if (index > count - 1)
            {
                return;
            }

            int number = index + 1;

            int leftNumber = number * 2;
            int rightNumber = leftNumber + 1;

            FirstTraversal(leftNumber - 1);
            Console.Write(data[index] + "   ");
            FirstTraversal(rightNumber - 1);
        }

        private void LastTraversal(int index)
        {
            if (index > count - 1)
            {
                return;
            }

            int number = index + 1;
            int leftNumber = number * 2;
            int rightNumber = leftNumber + 1;

            FirstTraversal(leftNumber - 1);
            FirstTraversal(rightNumber - 1);
            Console.Write(data[index] + "   ");
        }

        public void LayerTraversal()
        {
            for(int i = 0; i < count; ++i)
            {
                Console.Write(data[i] + "   ");
            }

            Console.WriteLine();
        }
    }
}
