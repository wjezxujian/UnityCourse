using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDS
{
    class StringDS
    {
        private char[] data;

        public StringDS(char[] array)
        {
            data = new char[array.Length];
            for(int i = 0; i < data.Length; ++i)
            {
                data[i] = array[i];
            }
        }

        public StringDS(string str)
        {
            data = new char[str.Length];
            for(int i = 0; i < str.Length; ++i)
            {
                data[i] = str[i];
            }
        }

        public char this[int index] { get => data[index]; }
        public int Length { get => data.Length; }

        public int GetLength()
        {
            return data.Length;
        }

        /**
         * 如果两个字符穿一样那么返回0
         * 如果当前字符串小于s，那么返回-1
         * 如果当前字符串大于s，那么返回1
         * 
         **/
        public int Compare(StringDS s)
        {
            int index = -1;
            int len = this.Length < s.Length ? this.Length : s.Length;

            for (int i = 0; i < len; ++i)
            {
                if (!this[i].Equals(s[i]))
                {
                    index = i;
                    break;
                }
            }

            if(index == -1)
            {
                return this.Length == s.Length ? 0 : this.Length > s.Length ? 1 : -1;
            }
            else
            {
                return this[index] - s[index] > 0 ? 1 : -1;
            }
        }

        public StringDS SubString(int index, int length)
        {
            char[] newData = new char[length];

            for(int i = index; i < index + length; ++i)
            {
                newData[i - index] = data[i];
            }

            return new StringDS(newData);
        }

        public static StringDS Concat(StringDS s1, StringDS s2)
        {
            char[] newData = new char[s1.Length + s2.Length];

            for(int i = 0; i < s1.Length; ++i)
            {
                newData[i] = s1[i];
            }

            for (int i = 0; i < s2.Length; ++i)
            {
                newData[i + s1.Length] = s2[i];
            }

            return new StringDS(newData);
        }

        public int IndexOf(StringDS s)
        {
            for (int i = 0; i <= Length - s.Length; ++i)
            {
                bool isEqual = true;
                for (int j = i; j < i + s.Length; ++j)
                {
                    if(this[j] != s[j - i])
                    {
                        isEqual = false;
                        break;
                    }
                }

                if (isEqual)
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            return new string(data);
        }


    }
}
