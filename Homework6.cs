namespace Homework6;
class Program
{
    static void Main(string[] args)
    {/*used UML to define Professor/Student classes with salary and grades being private variables. All info needed for calc is pulled from classes below*/
        Professor p1 = new Professor();
        p1.profName = "Alice";
        p1.classTeach = "Java";
        p1.SetSalary(9000);

        Professor p2 = new Professor();
        p2.profName = "Bob";
        p2.classTeach = "Math";
        p2.SetSalary(8000);

        Student s1 = new Student();
        s1.studentName = "Lisa";
        s1.classEnroll = "Java";
        s1.SetGrade(90);

        Student s2 = new Student();
        s2.studentName = "Tom";
        s2.classEnroll = "Math";
        s2.SetGrade(80);

/*Alternatively could have used WriteLine w/ PrintInfo under each class with a p1.PrintInfo under student in Main (for example)
but with UML diagram specifics being defined, I figured you wanted us to leave classes as UML instructed and work Q2 intructions under Main
WriteLine as used was pretty easy (copy/paste change p1 to p2 etc) with static input but wouldn't be the best method if using multiple professor/student inputs though*/

        Console.WriteLine("Professor " +p1.profName+ " teaches " +p1.classTeach+ ", and the salary is: " +p1.GetSalary());
        Console.WriteLine("Professor " +p2.profName+ " teaches " +p2.classTeach+ ", and the salary is: " +p2.GetSalary());
        Console.WriteLine("Student " +s1.studentName+ " enrolls " +s1.classEnroll+ ", and the grade is: " +s1.GetGrade());
        Console.WriteLine("Student " +s2.studentName+ " enrolls " +s2.classEnroll+ ", and the grade is: " +s2.GetGrade());

        double salaryDiff = p1.GetSalary() - p2.GetSalary(); // returns salary using GetSalary under Professor class
        Console.WriteLine("The salary difference between " +p1.profName+ " and " +p2.profName+ " is: " +salaryDiff);
        double totGrade = s1.GetGrade() + s2.GetGrade(); //same as above, return grade using GetGrade under Student class
        Console.WriteLine("The total grade of " +s1.studentName+ " and " +s2.studentName+ " is: " +totGrade);
    }
}
public class Professor{
    public string profName;
    public string classTeach;
    private double salary;//UML specified private salary, could set as public property using {get;set;} method

    public void SetSalary(double salary_amount){
        salary = salary_amount;
    }
    
    public double GetSalary(){
        return salary;
    }
}
public class Student{
    public string studentName;
    public string classEnroll;
    private double studentGrade;//uml specified private grade

    public void SetGrade(double newGrade){
        studentGrade = newGrade;
    }
    public double GetGrade(){
        return studentGrade;
    }
}