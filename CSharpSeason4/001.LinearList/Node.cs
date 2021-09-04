using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001.LinearList
{
    class Node<T>
    {
        private T data;
        private Node<T> next;

        public Node()
        {
            data = default(T);
            this.next = null;
        }

        public Node(T value, Node<T> next = null)
        {
            this.data = value;
            this.next = next;
        }

        public Node(Node<T> next) : this()
        {
            this.next = next;
        }

        public T Data { get { return data; } set { data = value; } }

        public Node<T> Next { get { return next; } set { next = value; } }
    }
}
