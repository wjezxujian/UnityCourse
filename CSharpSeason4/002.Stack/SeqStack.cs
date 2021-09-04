using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002.StackEx
{
    class SeqStack<T> : IStackDS<T>
    {
        private T[] data;
        private int top;

        public int Count { get => top + 1; }

        public SeqStack(int size = 0)
        {
            size = size == 0 ?  16 : size;
            data = new T[size];
            top = -1;
        }

        public void Clear()
        {
            top = -1;
        }

        public int GetLength()
        {
            return top + 1;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public T Peek()
        {
            return data[top];
        }

        public T Pop()
        {
            T temp = data[top];
            --top;
            return temp;
        }

        public void Push(T item)
        {
            data[++top] = item;
        }
    }
}
