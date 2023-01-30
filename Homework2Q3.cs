namespace Homework2Q3;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Please input a year : ");
        int year = Convert.ToInt16(Console.ReadLine());

 //mathisfun.com states leap yr is any year exactly divided by 4, not able to be divided by 100, and then exactly divided by 400
        if ((year%4 == 0 && year%100 != 0) || year%400 == 0)
        {
            Console.WriteLine(year + " is a Leap Year.");
        }
        else {
            Console.WriteLine(year + " is not a Leap Year.");
        }
        
    }
}
