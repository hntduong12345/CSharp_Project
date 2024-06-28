// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//input n,k;
//Calculate N!
//Calculate K!

int Factorial(int n)
{
    int result = 1;
    for (int i = 2; i <= n; i++)
    {
        result *= i;
    }
    return result;
}

Console.Write("Input n:");
int n = Convert.ToInt32(Console.ReadLine());

Console.Write("Input k:");
int k = Convert.ToInt32(Console.ReadLine());

var ans = Factorial(n) / (Factorial(k) * Factorial(n - k));

Console.WriteLine("Result = {0}", ans);
