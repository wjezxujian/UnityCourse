using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001.LinearList
{
    class LinkList<T> : IListDS<T>
    {
        private Node<T> head;
        private int count;
        public T this[int index] { get => this.GetEle(index); set { } }

        public LinkList()
        {
            head = null;
        }

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if(head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> lastNode = head;
                while (lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                }

                lastNode.Next = newNode;
            }

            ++count;
        }

        public void Clear()
        {
            count = 0;
            head = null;
        }

        public T Delete(int index)
        {
            T data = default(T);

            if (index == 0)
            {
                head = head.Next;
                data = head.Data;
            }
            else if (index >= 0 && index < count - 1)
            {
                Node<T> prevNode = GetNode(index - 1);
                Node<T> currNode = prevNode.Next;
                Node<T> afterNode = currNode.Next.Next;

                prevNode.Next = afterNode;
                data = currNode.Data;
            }
            else
            {
                Node<T> lastNode = GetNode(index - 1);
                data = lastNode.Next.Data;
                lastNode.Next = null;
            }

            --count;
            return data;
        }

        public T GetEle(int index)
        {
            return GetNode(index).Data;
        }

        Node<T> GetNode(int index)
        {
            Node<T> tempNode = head;
            for (int i = 0; i <= index - 1; ++i)
            {
                tempNode = tempNode.Next;
            }

            return tempNode;
        }


        public int GetLength()
        {
            return count;
        }

        public void Insert(T item, int index)
        {
            Node<T> newNode = new Node<T>(item);

            if(index == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else if(index >= 0 && index < count - 1)
            {
                Node<T> prevNode = GetNode(index - 1);
                Node<T> afterNode = prevNode.Next;

                prevNode.Next = newNode;
                newNode.Next = afterNode;
            }
            else
            {
                Node<T> lastNode = GetNode(index - 1);
                lastNode.Next = newNode;
            }

            ++count;            
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public int Locate(T value)
        {
            int index = -1;
            Node<T> tempNode = head;
            while (tempNode != null && !(tempNode.Data.Equals(value) && ++index >= -1))
            {
                tempNode = tempNode.Next;
                ++index;
            }

            return index;
        }
    }
}
