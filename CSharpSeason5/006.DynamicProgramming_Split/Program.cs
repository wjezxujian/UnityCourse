using System;

namespace _006.DynamicProgramming_Split
{
    class Program
    {
        static int[] result;
        static int[] prices = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

        static void Main(string[] args)
        {
            int n = 2100000000;
            result = new int[n + 1];
            Console.WriteLine("1: " + DownUp(1));
            Console.WriteLine("2: " + DownUp(2));
            Console.WriteLine("3: " + DownUp(3));
            Console.WriteLine("4: " + DownUp(4));
            Console.WriteLine("5: " + DownUp(5));
            Console.WriteLine("6: " + DownUp(6));
            Console.WriteLine("7: " + DownUp(7));
            Console.WriteLine("8: " + DownUp(8));
            Console.WriteLine("9: " + DownUp(9));
            Console.WriteLine("10: " + DownUp(10));
            Console.WriteLine("11: " + DownUp(11));
            Console.WriteLine("12: " + DownUp(12));
            Console.WriteLine("13: " + DownUp(13));
            Console.WriteLine("14: " + DownUp(14));
            Console.WriteLine("15: " + DownUp(15));
            Console.WriteLine("16: " + DownUp(16));
            Console.WriteLine("17: " + DownUp(17));
            Console.WriteLine("18: " + DownUp(18));
            Console.WriteLine("19: " + DownUp(19));
            Console.WriteLine("20: " + DownUp(20));
            Console.WriteLine("100: " + DownUp(100));
            Console.WriteLine("111: " + DownUp(111));
            Console.WriteLine("1111: " + DownUp(1111));
            Console.WriteLine("11111: " + DownUp(11111));
            Console.WriteLine("999999: " + DownUp(999999));


            Console.ReadKey();


        }

        //自顶向下
        //public static int UpDown(int n)
        //{
        //    //if (n <= 0) return 0;

        //    //int totalPrice = 0;

        //    //for (int i = 1; i < n + 1; ++i)
        //    //{
        //    //    int maxPrice = prices[i] + UpDown(n - i);
        //    //    if (maxPrice > totalPrice) totalPrice = maxPrice;
        //    //}


        //    //return totalPrice;
        //}

        //自底向上
        public static int DownUp(int n)
        {
            if (n <= 0) return 0;
            if (n <= 10)
            {
                result[n] = prices[n];
                return result[n];
            }
            

            for (int i = 1; i <= n; ++i)
            {
                if(result[i] == 0)
                {
                    int tempPrice = 0;
                    for (int j = 1; j <= i; ++j)
                    {
                        int maxPrice = result[j] + result[i - j];
                        tempPrice = maxPrice > tempPrice ? maxPrice : tempPrice;
                    }
                    result[i] = tempPrice;
                }
                
            }

            return result[n];
        }
    }
}

