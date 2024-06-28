using System;

namespace P4
{
    class P4
    {
        static void Main(string[] args)
        {
            int count = 0;
            //Console.Write("Input n: ");
            //int n = Convert.ToInt32(Console.ReadLine());
            int n = 17;
            for (int i  = n; i <= 1000; i+=n)
            {
                if(i % n == 0)
                {
                    count++;
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine("Numbers of num satified requirement: {0}", count);
        }
    }
}
