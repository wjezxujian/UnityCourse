using System;

namespace _005.HeapSort
{
    class Program
    {


        static void Main(string[] args)
        {
            int[] data = { 50, 10, 90, 30, 70, 40, 80, 60, 20 };

            HeapSort(data);

            foreach(int temp in data)
            {
                Console.Write(temp + "  ");
            }

            Console.WriteLine();

            Console.ReadKey();
        }

        static public void HeapSort(int[] data)
        {
            //便利这个数的所有非叶子节点，挨个把子数变成大顶堆
            for (int i = data.Length / 2; i >= 1; --i)
            {
                HeapAjust(data, i, data.Length);
            }

            //经过上面循环把上面变成了大顶堆

            //把编号i和编号1的位置进行交换
            //把1到（i-1）重新构造成大顶堆
            for (int i = data.Length; i > 1; --i)
            {
                int temp = data[0];
                data[0] = data[i - 1];
                data[i - 1] = temp;

                HeapAjust(data, 1, i - 1);
            }
        }

        static public void HeapAjust(int[] data, int numberToAjust, int maxNumber)
        {
            int tempI = numberToAjust;

            while (true)
            {
                //把i节点子树变成大顶堆
                int maxNodeNumber = tempI;
                int leftChildNumber = tempI * 2;
                int rightChildNumber = leftChildNumber + 1;

                if (leftChildNumber <= maxNumber && data[leftChildNumber - 1] > data[maxNodeNumber - 1])
                {
                    maxNodeNumber = leftChildNumber;
                }

                if (rightChildNumber <= maxNumber && data[rightChildNumber - 1] > data[maxNodeNumber - 1])
                {
                    maxNodeNumber = rightChildNumber;
                }

                //发现一个更大的子节点交换
                if (maxNodeNumber != tempI)
                {
                    int temp1 = data[tempI - 1];
                    data[tempI - 1] = data[maxNodeNumber - 1];
                    data[maxNodeNumber - 1] = temp1;
                    tempI = maxNodeNumber;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
