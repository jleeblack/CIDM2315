namespace Homework2;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Please input a letter grade:");
        string grade = Console.ReadLine();

//used case to display GPa based off of string grade "A through F" with indicator for incorrect grade letters
        switch (grade) {
            case "A":
            Console.WriteLine("GPA is 4");
            break;

            case "B":
            Console.WriteLine("GPA is 3");
            break;

            case "C":
            Console.WriteLine("GPA is 2");
            break;

            case "D":
            Console.WriteLine("GPA is 1");
            break;

            case "F":
            Console.WriteLine("GPA is 0");
            break;

        default:
            Console.WriteLine("Wrong Letter Grade!");
            break;    
        }
        }
    }
