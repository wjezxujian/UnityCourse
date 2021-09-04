using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003.QueueEx
{
    class SeqQueue<T> : IQueueDS<T>
    {
        private T[] data;
        private int front;  //(队首索引元素-1)
        private int rear;   //(队尾索引)
        private int count = 0;

        public int Count => count;

        public SeqQueue(int size = 0)
        {
            if (size == 0) size = 16;
            data = new T[size];
            front = rear = -1;
            count = 0;
        }

        public void Clear()
        {
            front = rear = -1;
            count = 0;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("队列空，不可以出栈数据");
                return default(T);
            }
            else
            {
                T temp = data[front + 1];
                front = (front + 2) % data.Length - 1;
                --count;
                return temp;
            }
        }

        public void Enqueue(T item)
        {
            if (count == data.Length)
            {
                Console.WriteLine("队列已满，不可以在添加新的数据");
            }
            else
            {
                rear =  (rear + 1) % data.Length;
                data[rear] = item;
                ++count;
            }
        }

        public int GetLength()
        {
            return count;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public T Peek()
        {
            return data[front + 1];
        }
    }
}
