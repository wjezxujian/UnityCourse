using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003.QueueEx
{
    class LinkQueue<T> : IQueueDS<T>
    {
        private Node<T> front;
        private Node<T> rear;
        private int count;


        public int Count => count;

        public LinkQueue()
        {
            front = rear = null;
            count = 0;
        }

        public void Clear()
        {
            front = rear = null;
            count = 0;
        }

        public T Dequeue()
        {
            if(count == 0)
            {
                Console.WriteLine("队列为空，无法出栈");
                return default(T);
            }
            else if(count == 1)
            {
                T temp = front.Data;
                front = rear = null;
                --count;
                return temp;
            }
            else
            {
                T temp = front.Data;
                front = front.Next;
                --count;
                return temp;
            }
        }

        public void Enqueue(T item)
        {
            Node<T> temp = new Node<T>(item);

            if(front == null)
            {
                front = temp;
                rear = temp;
            }
            else
            {
                rear.Next = temp;
                rear = temp;
            }
            ++count;
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
            if(front != null)
            {
                return front.Data;
            }
            else
            {
                return default(T);
            }
        }
    }
}
