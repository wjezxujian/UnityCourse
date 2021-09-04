using System;
using System.Collections;
using System.Collections.Generic;

namespace _002.StackEx
{
    class Program
    {
        static void Main(string[] args)
        {
            ////1.使用BCL中的Stack<T>
            //Stack<char> stack = new Stack<char>();
            ////2.使用自定义SeqStack<T>
            //IStackDS<char> stack = new SeqStack<char>();
            //3.使用自定LinkStack<T>
            LinkStack<char> stack = new LinkStack<char>();

            stack.Push('a');
            stack.Push('b');
            stack.Push('c');
            Console.WriteLine("Count: " + stack.Count);

            char charTemp = stack.Pop();
            Console.WriteLine("Pop Char: " + charTemp);
            Console.WriteLine("Pop 之后Count: " + stack.Count);


            char charTemp2 = stack.Peek();
            Console.WriteLine("Peek Char: " + charTemp2);
            Console.WriteLine("Peek 之后Count: " + stack.Count);

            stack.Clear();
            Console.WriteLine("Clear 之后Count: " + stack.Count);

            //char emptyTemp = stack.Peek();
            //Console.WriteLine("空栈异常：" + emptyTemp);

            Console.ReadKey();
        }
    }
}
