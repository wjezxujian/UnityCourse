using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002.StackEx
{
    class Node<T>
    {
        private T data;
        private Node<T> head;

        public T Data { get => data; set => data = value; }
        public Node<T> Head { get => head; set => head = value; }

        public Node()
        {
            data = default(T);
            head = null;
        }

        public Node(T data, Node<T> head = null)
        {
            this.data = data;
            this.head = head;
        }

        public Node(Node<T> head)
        {
            this.head = head;
        }

        
    }
}
