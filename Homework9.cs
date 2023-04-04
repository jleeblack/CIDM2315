namespace Homework9;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args){
        Student s1 = new Student(111,"Alice");//step 2 - create 4 students as input
        Student s2 = new Student(222,"Bob");
        Student s3 = new Student(333,"Cathy");
        Student s4 = new Student(444,"David");

        Dictionary<string,double> gradebook = new Dictionary<string,double>(){//step 3 creates dictionary using the below pairs of names/gpas
            {"Alice",4.0},
            {"Bob",3.6},
            {"Cathy",2.5},
            {"David",1.8},
        };
        if (!gradebook.ContainsKey("Tom")){//step 4 - this checks Dictionary "gradebook" for an entry named "Tom" - if false it adds Tom with his 3.3 GPA
            gradebook.Add("Tom",3.3);
        }
        double avgGPA = gradebook.Values.Average();//step 5 used System.Linq to allow easily average function
        Console.WriteLine("The average GPA is: {0}", avgGPA);

        foreach (Student student in Student.studentList){//step 6 checks to see which students have GPAs > avgGPA and prints via PrintInfo
            if (gradebook.ContainsKey(student.Name) &&gradebook[student.Name]>avgGPA){
                student.PrintInfo();
            }
        }
    }
}
class Student
{
    private int studentID;
    private string studentName;
    public static List<Student> studentList = new List<Student>();
    public Student(int id, string name){//step 1 - Create student class
        studentID= id;
        studentName= name;
        studentList.Add(this);
    }
    public void PrintInfo(){
        Console.WriteLine("Student ID: {0}, Student Name: {1}", studentID, studentName);
    }
    public string Name{
        get{return studentName;}
    }
}
