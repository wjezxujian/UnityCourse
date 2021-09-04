using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001.LinearList
{
    class SeqList<T> : IListDS<T>
    {
        private T[] data;
        private int count = 0;

        public T this[int index] { get => GetEle(index); set { if (index < count && index >= 0) data[index] = value; } }

        public SeqList(int size = 0)
        {
            if(size == 0)
            {
                size = 8;
            }

            data = new T[size];
            count = 0;
        }

        public void Add(T item)
        {
            AutoSize();

            //data.Append(item);
            data[count] = item;
            ++count;
        }

        public void Clear()
        {
            //for (int i = 0; i < count; ++i) 
            //{
            //    data[i] = default(T);
            //}

            count = 0;
        }

        public T Delete(int index)
        {
            if(index >= 0 && index < count)
            {
                T temp = data[index];

                for (int i = index; i < count; ++i)
                {
                    data[i] = data[i + 1];
                }

                --count;

                return temp;
            }
            else
            {
                return default(T);
            }
            
        }

        public T GetEle(int index)
        {
            if(index >= 0 && index < count)
            {
                return data[index];
            }
            else
            {
                Console.WriteLine("当前索引不存在");
                return default(T);
            }
        }

        public int GetLength()
        {
            return count;
        }

        public void Insert(T item, int index)
        {
            AutoSize();

            for(int i = count; i > index; --i)
            {
                data[i] = data[i - 1];
            }

            data[index] = item;
            ++count;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public int Locate(T value)
        {
            for (int i = 0; i < count; ++i)
            {
                if(data[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        private void AutoSize()
        {
            if(count >= data.Length)
            {
                T[] tempData = new T[count * 2];
                Array.Copy(data, tempData, count);
                data = tempData;
            }
        }
    }
}
