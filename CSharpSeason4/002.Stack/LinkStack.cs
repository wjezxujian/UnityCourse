using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002.StackEx
{
    class LinkStack<T> : IStackDS<T>
    {
        private Node<T> top;
        private int count = 0;

        public int Count => count;

        public void Clear()
        {
            count = 0;
            top = null;
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
            return top.Data;
        }

        public T Pop()
        {
            Node<T> temp = top;
            top = temp.Head;
            --count;

            return temp.Data;
        }

        public void Push(T item)
        {
            Node<T> temp = new Node<T>(item);
            temp.Head = top;
            top = temp;

            ++count;
        }
    }
}
