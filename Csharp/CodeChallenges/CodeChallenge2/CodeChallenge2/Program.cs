using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge2
{
   //First Question
    // Abstract class Student
    abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }

        // Abstract method
        public abstract bool IsPassed(double grade);
    }

    // UnderGraduate class
    class UnderGraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade >= 70.0;
        }
    }

    // Graduate class
    class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade >= 80.0;
        }
    }

    // Main class
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter Student Type UG for UnderGraduate and PG for Graduate:");
            string type = Console.ReadLine().ToUpper();

            Student student;

            if (type == "UG")
            {
                student = new UnderGraduate();
            }
            else if (type == "PG")
            {
                student = new Graduate();
            }
            else
            {
                Console.WriteLine("Invalid student type entered.");
                return;
            }

            Console.Write("Enter Student Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter Student ID: ");
            student.StudentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Grade: ");
            student.Grade = double.Parse(Console.ReadLine());

            bool result = student.IsPassed(student.Grade);

            Console.WriteLine("===========Studeent Details===========");
            Console.WriteLine($"Student Type: {type}");
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Student ID: {student.StudentId}");
            Console.WriteLine($"Grade: {student.Grade}");
            Console.WriteLine($"Passed: {result}");
            Console.Read();
        }
    }

}
