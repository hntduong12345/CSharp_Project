// See https://aka.ms/new-console-template for more information
using System.Globalization;

Console.WriteLine("Hello, World!");
Console.WriteLine("My name is D");

int n = 100;

Console.WriteLine("Please input a number");
var input = Console.ReadLine();
n = int.Parse(input);


int sum = 0;
for (int i = 0; i <= n; i++)
{
    if (i % 2 == 0)
    {
        sum += i;
    }
}

Console.WriteLine("Sum of even numbers from 1 to {0}: {1}", n, sum);