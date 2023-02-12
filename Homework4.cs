namespace Homework4;
class Program
{
    static void Main(string[] args)
    {// Two inputs are entered and converted to int32 from string
        Console.WriteLine("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        int large = LargestNumber(a, b);//calls from method LargestNumber
        Console.WriteLine();//The output was coming out scrunched up, this was a simple/effective way to create space
        Console.WriteLine("a = "+ a +"; b = "+ b);
        Console.WriteLine("The largest number is: "+ large);
        Console.WriteLine();
        
        //second half of homework for creating shapes associated with N
        Console.WriteLine("Enter number of rows: ");
        int N = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Shape left or right?: ");
        string shape = Console.ReadLine().ToLower();//I didn't like that any use of capitalization in input returned error. This fix converts string to lowercase

        while (shape!= "left" && shape!= "right")//My prev HW didn't address incorrect strings, this while function identifies incorrect input and gives user new input opportunity to correct
        {
            Console.WriteLine();
            Console.WriteLine("Shape entered incorrectly - Please input left or right.");
            shape = Console.ReadLine().ToLower();
        }

        WriteShape(N, shape);
    }

    static int LargestNumber(int a, int b){//method calcs the largest out of a or b
        if (a>b){
            return a;
        }
        else{
            return b;
        }
    }
    
    static void WriteShape(int N, string shape){// this creates the shapes dependant on rows requested
        Console.WriteLine();
        Console.WriteLine("N is: "+N +"; shape is "+shape);
        if (shape == "left"){
            for (int i=1; i<= N; i++){
                for (int j=1; j<= i; j++){
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        else if (shape == "right"){
            for (int i=1; i<= N; i++){
                for (int j=1; j<= N - i; j++){//I forgot to insert the -i from N on a previous hw assignment which gave wrong output. I dblchecked this time.
                    Console.Write(" ");
                }
                for (int j=1; j<= i; j++){
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            }
        }
    }