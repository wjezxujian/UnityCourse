using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004.BinarySortTree
{
    class BinarySortNode<T> where T:IComparable
    {
        T data;
        private BinarySortNode<T> leftChild;
        private BinarySortNode<T> parent;
        private BinarySortNode<T> rightChild;

        public T Data { get => data; set => data = value; }
        public BinarySortNode<T> LeftChild { get => leftChild; set => leftChild = value; }
        public BinarySortNode<T> Parent { get => parent; set => parent = value; }
        public BinarySortNode<T> RightChild { get => rightChild; set => rightChild = value; }

        public BinarySortNode(T item)
        {
            data = item;
        }

        public int CompareTo(BinarySortNode<T> node)
        {
            return data.CompareTo(node.data);
        }
    }
}
