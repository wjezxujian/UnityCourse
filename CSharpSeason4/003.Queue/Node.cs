using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003.QueueEx
{
    class Node<T>
    {
        private T data;
        private Node<T> next;

        public Node(T data)
        {
            this.data = data;
        }

        public T Data { get => data; set => data = value; }
        public Node<T> Next { get => next; set => next = value; }
    }
}
