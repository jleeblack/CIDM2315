namespace Homework7;
class Program
{//Program class creates the two customers (Alice and Bob) and prints the requested information and calls PrintCusInfo / CompareAge
    static void Main(string[] args){
        Customer c1 = new Customer(110, "Alice", 28);
        Customer c2 = new Customer(111, "Bob", 30);
        c1.PrintCusInfo();
        c2.PrintCusInfo();
        c1.ChangeID(220);
        c2.ChangeID(221);
        c1.PrintCusInfo();
        c2.PrintCusInfo();
        c1.CompareAge(c2);
        }
}
public class Customer{
    private int cus_id;
    public string cus_name;
    public int cus_age;
    public Customer(int cus_id, string cus_name, int cus_age){//This is the constructor
        this.cus_id=cus_id;
        this.cus_name=cus_name;
        this.cus_age=cus_age;
    }
    public void ChangeID(int new_id){//changes customer id
        this.cus_id=new_id;
    }
    public void PrintCusInfo(){//prints customer id, name, age
        Console.WriteLine("Customer: {0}, name: {1}, age:{2}", this.cus_id, this.cus_name, this.cus_age);
    }
    public void CompareAge(Customer objCustomer){//compares age and prints name of older customer used if/else if/else
        if(this.cus_age>objCustomer.cus_age){
            Console.WriteLine("{0} is older", this.cus_name);
        }
        else if(this.cus_age<objCustomer.cus_age){
            Console.WriteLine("{0} is older", objCustomer.cus_name);
        }
        else{//for customer same age
            Console.WriteLine("{0} and {1} are the same age", this.cus_name, objCustomer.cus_name);
        }
    }
}
