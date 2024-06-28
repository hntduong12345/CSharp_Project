using System;

namespace P5
{
    class P5
    {
        static void Main(string[] args)
        {
            int num, temp;
            int count = 0;
            do
            {
                temp = Convert.ToInt32(Console.ReadLine());
                if(temp % 17 == 0)
                {
                    count++;
                }
            }while (count != 7);
        }
    }
}
