namespace Homework2Q2;
class Program
{
    static void Main(string[] args) {
        Console.WriteLine($"Please input the first num:");
        int numOne = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine($"Please input the second num:");
        int numTwo = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine($"Please input the third num:");
        int numThree = Convert.ToInt16(Console.ReadLine());

//used if/else if/else and the && function to check the numbers against themselves and verify lowest entered integer
        if (numOne<numTwo && numOne<numThree) {
                Console.WriteLine("The smallest value is: " + numOne);
            }
        else if (numTwo<numOne && numTwo<numThree) {
            Console.WriteLine("The smallest value is: " + numTwo);
            }    
        else {
            Console.WriteLine("The smallest value is: " + numThree);
        }
    }    
}         