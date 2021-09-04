using System;
using System.Collections.Generic;

namespace _004.QueueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            Queue<char> queue = new Queue<char>();

            for(int i = 0; i < str.Length; ++i)
            {
                stack.Push(str[i]);
                queue.Enqueue(str[i]);
            }

            bool isPalindrome = true;
            while (stack.Count > 0)
            {
                if (!stack.Pop().Equals(queue.Dequeue()))
                {
                    isPalindrome = false;
                    break;
                }
            }

            Console.WriteLine("输入字符串是否是回文：" + isPalindrome);

            Console.ReadKey();
        }
    }
}
