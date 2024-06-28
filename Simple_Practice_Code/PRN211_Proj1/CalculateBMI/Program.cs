using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace P6
{
    class P6
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            double weight, height;
            Console.Write("Input Weight (kg): ");
            weight = Convert.ToDouble(Console.ReadLine());
            Console.Write("Input Height (cm): ");
            height = Convert.ToDouble(Console.ReadLine());

            var bmi = BMICal(weight, height);
            Console.WriteLine("BMI = {0}", bmi);

            Console.WriteLine("Đánh Giá Chung:");
            if (bmi < 18.5)
            {
                Console.WriteLine("Nhẹ Cân");
            }
            else if(bmi>= 18.5 && bmi<25){
                Console.WriteLine("Bình Thường");
            }
            else if(bmi>=25 && bmi < 30)
            {
                Console.WriteLine("Thừa Cân");
            }
            else if (bmi>=30 && bmi<35)
            {
                Console.WriteLine("Béo Phì");
            }
            else
            {
                Console.WriteLine("Quá Béo Phì");
            }
        }

        static double BMICal(double m, double h)
        {
            return (m*10000) / (h * h);
        }
    }
}
