using System;

namespace PTB2
{
    class PTB2
    {
        static void Main(string[] args)
        {
            double a, b, c;
            Console.WriteLine("ax^2 + bx +c = 0");
            Console.Write("Input a: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input b: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input c: ");
            c = Convert.ToInt32(Console.ReadLine());

            if (a == 0 && b == 0 && c == 0)
            {
                Console.WriteLine("Infinity");
            }
            else if (a == 0 && b == 0 && c != 0)
            {
                Console.WriteLine("No Solution");
            }
            else if (a == 0 && b != 0)
            {
                var ans = -c / b;
                Console.WriteLine("One Solution");
                Console.WriteLine("x = {0}", ans);
            }
            else if (a != 0)
            {
                delta(a, b, c);
            }
        }

        static void delta(double a, double b, double c)
        {
            var d = b * b - 4 * a * c;
            if(d > 0)
            {
                var x1 = (-b - Math.Sqrt(d)) / (2*a);
                var x2 = (-b + Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("2 Solution:");
                Console.WriteLine("x1 = {0}",x1);
                Console.WriteLine("x2 = {0}",x2);
            }
            else if(d == 0)
            {
                var x = -b / (2 * a);
                Console.WriteLine("1 Solution:");
                Console.WriteLine("x = {0}", x);
            }
            else
            {
                Console.WriteLine("No Solution");
            }
        }
    }
}
