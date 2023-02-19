namespace Homework5;
class Program
{
    static void Main(string[] args)
    //original plan was to ask user to input whether they were using 2 or 4 integers, but that seemed clumsy and not user friendly. opted for detection and proper handling of two or four
    {//this method detects the use of either 2 or 4 seperate ints and identifies/reacts accordingly through a split array of strings
        Console.WriteLine("Please enter two or four positive integers, separated by spaces: (ex. 1 2 3 4):");
        string input = Console.ReadLine();
        string[] numbers = input.Split();//splitting the input into an array to fix errors I kept receiving when 4 large integers were input instead of 2

        int max = 0;
        if (numbers.Length == 2){
            int a = Convert.ToInt32(numbers[0]);
            int b = Convert.ToInt32(numbers[1]);
            max = LargestNumber(a, b);
        }
        else if (numbers.Length == 4){//i use this to store all 4 input integers
            int[] inputs = new int[4];
            for (int i = 0; i < 4; i++){
                inputs[i] = Convert.ToInt32(numbers[i]);
            }

            int max1 = LargestNumber(inputs[0], inputs[1]);
            int max2 = LargestNumber(inputs[2], inputs[3]);
            max = LargestNumber(max1, max2);
        }
        else{
            Console.WriteLine("Invalid input. Please enter 2 or 4 integers, separated by spaces: (ex. 1 2 3):");
            return;
        }
        Console.WriteLine();
        Console.WriteLine("The largest number is: " + max);
        Console.WriteLine();

        CreateAccount();//this call initiates Q3 homework using CreateAccount method to defined output and expected inputs (and within itself calls to CheckAge method for >=18)
    }
//this was the most logical way I found to provide correct output for 2 and 4 integers while leaving LargestNumber as it was on Q1
    static int LargestNumber(int a, int b){//method calcs the largest out of a or b
        if (a > b){
            return a;
        }
        else{
            return b;
        }
    }//i originally attempted to use an overloaded method here to process the 4 int input using max1 and max2 comparisons with a return of LargestNumber(max1,max2)
    //this method created output errors when it couldn't properly distinguish between int input of 2 vs 4 and felt clumsy in design
    //opted to redesign using number array via .split and storing integers to ensure proper output of 4 large integers, which I hope is okay.

    static bool CheckAge(int birth_year){
        int age = DateTime.Now.Year - birth_year;//Even though 2022-birth_year was provided in the example, I ran into issues with this if I input 2022.
        return age >= 18;
    }

    static void CreateAccount(){
        Console.WriteLine("Enter Your Username:");
        string username = Console.ReadLine();

        Console.WriteLine("Enter your password:");
        string password1 = Console.ReadLine();

        Console.WriteLine("Enter Your Password Again:");
        string password2 = Console.ReadLine();

        Console.WriteLine("Enter Your Birthyear:");
        int birthyear = Convert.ToInt32(Console.ReadLine());

        if (!CheckAge(birthyear)){//if/elseif/else statement used to ensure proper status is displayed depending on age and ==password
            Console.WriteLine("Could not create an account.");
        }

        else if (password1 == password2){
            Console.WriteLine("Account is created successfully.");
        }

        else{
            Console.WriteLine("Wrong password.");
        }
    }
}
