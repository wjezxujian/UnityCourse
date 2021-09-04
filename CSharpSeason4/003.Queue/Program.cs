using System;
using System.Collections.Generic;

namespace _003.QueueEx
{
    class Program
    {
        static void Main(string[] args)
        {
            ////1.使用BCL中的队列
            //Queue<int> queue = new Queue<int>();

            ////2.使用自定义顺序队列
            //SeqQueue<int> queue = new SeqQueue<int>();

            //3.使用我们的链队列
            LinkQueue<int> queue = new LinkQueue<int>();

            queue.Enqueue(12);
            queue.Enqueue(34);
            queue.Enqueue(56);
            queue.Enqueue(78);
            Console.WriteLine("Count: " + queue.Count);

            int peekTemp = queue.Peek();
            Console.WriteLine("peekTemp: " + peekTemp);
            Console.WriteLine("Count: " + queue.Count);

            int dequeueTemp = queue.Dequeue();
            Console.WriteLine("dequeueTemp: " + dequeueTemp);
            Console.WriteLine("Count: " + queue.Count);

            int dequeueTemp2 = queue.Dequeue();
            Console.WriteLine("dequeueTemp2: " + dequeueTemp2);
            Console.WriteLine("Count: " + queue.Count);

            queue.Clear();
            Console.WriteLine("Clear Count: " + queue.Count);

            Console.ReadKey();
        }
    }
}
