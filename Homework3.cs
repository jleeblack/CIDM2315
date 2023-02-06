using System;
namespace Homework3;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input an integer:");//HomeworkQ1
        int n = Convert.ToInt32(Console.ReadLine());
        int p = 0;

        for (int i = 1; i <= n; i++)
        {
            if (n%i == 0)
            {
                p++;
            }
        }
        if (p == 2)
        {
            Console.WriteLine($"{n} is prime");
        }
        else
        {
            Console.WriteLine($"{n} is non-prime");
        }

        Console.WriteLine("Assign an int value to N:");//HomeworkQ2

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("#");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Assign an int value to N:");//HomeworkQ3

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        
        Console.WriteLine("Assign an int value to N:");//HomeworkBonus

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
    }
}    
