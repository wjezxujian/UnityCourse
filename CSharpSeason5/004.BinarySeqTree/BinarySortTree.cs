using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004.BinarySortTree
{
    class BinarySortTree<T> where T:IComparable
    {
        BinarySortNode<T> root;

        public BinarySortTree()
        {
            root = null;
        }
        public void Add(T item)
        {
            var newNode = new BinarySortNode<T>(item);

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                BinarySortNode<T> tempNode = root;
                while (true)
                {
                    if (newNode.CompareTo(tempNode) == -1)
                    {
                        if(tempNode.LeftChild == null)
                        {
                            tempNode.LeftChild = newNode;
                            newNode.Parent = tempNode;
                            break;
                        }
                        else
                        {
                            tempNode = tempNode.LeftChild;
                        }
                    }
                    else
                    {
                        if (tempNode.RightChild == null)
                        {
                            tempNode.RightChild = newNode;
                            newNode.Parent = tempNode;
                            break;
                        }
                        else
                        {
                            tempNode = tempNode.RightChild;
                        }
                    }
                }
            }
        }

        public bool Delete(T item)
        {
            BinarySortNode<T> temp = root;
            while (true)
            {
                if (temp == null) return false;

                if (item.Equals(temp.Data))
                {
                    Delete(temp);

                    return true;
                }
                else if (item.CompareTo(temp.Data) < 0)
                {
                    temp = temp.LeftChild;
                }
                else
                {
                    temp = temp.RightChild;
                }
            }
        }

        public void Delete(BinarySortNode<T> node)
        {
            if (node.LeftChild == null && node.RightChild == null)
            {
                if (node.Parent == null)
                {
                    root = null;
                }
                else if (node.Parent.LeftChild == node)
                {
                    node.Parent.LeftChild = null;
                }
                else if (node.Parent.LeftChild == node)
                {
                    node.Parent.RightChild = null;
                }
                node.LeftChild.Parent = null;
            }
            else if(node.LeftChild == null && node.RightChild != null)
            {
                node.Data = node.RightChild.Data;
                node.RightChild.Parent = null;
                node.RightChild = null;
            }
            else if (node.LeftChild != null && node.RightChild == null)
            {
                node.Data = node.LeftChild.Data;
                node.LeftChild.Parent = null;
                node.LeftChild = null;
            }
            else
            {
                BinarySortNode<T> tempNode = node.RightChild;
                while (true)
                {
                    if (tempNode.LeftChild != null)
                    {
                        tempNode = tempNode.LeftChild;
                    }
                    else
                    {
                        break;
                    }
                }

                if (tempNode.RightChild == null)
                {
                    node.Data = tempNode.Data;
                    tempNode.Parent.LeftChild = null;
                }
                else
                {
                    //TODO 需要循环处理
                    node.Data = tempNode.Data;
                    tempNode.Data = tempNode.RightChild.Data;
                    tempNode.RightChild = null;
                }
            }
        }

        public bool Find(T item)
        {
            //return Find(item, root);

            BinarySortNode<T> temp = root;
            while (true)
            {
                if (temp == null) return false;

                if (item.Equals(temp.Data))
                {
                    return true;
                }
                else if(item.CompareTo(temp.Data) < 0)
                {
                    temp = temp.LeftChild;
                }
                else
                {
                    temp = temp.RightChild;
                }
            }
        }

        private bool Find(T item, BinarySortNode<T> node)
        {
            if (node == null) return false;

            if (item.Equals(node.Data))
            {
                return true;
            }
            else if (item.CompareTo(node.Data) < 0)
            {
                return Find(item, node.LeftChild);
            }
            else
            {
                return Find(item, node.RightChild);
            }
        }

        public void MiddleTraversal()
        {
            MiddleTraversal(root);
            Console.WriteLine();
        }

        private void MiddleTraversal(BinarySortNode<T> node)
        {
            if (root == null) return;

            if(node.LeftChild != null) MiddleTraversal(node.LeftChild);
            Console.Write(node.Data + " ");
            if(node.RightChild != null) MiddleTraversal(node.RightChild);
        }
    }
}
