using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    //Third Question (Student Results)
    class Student
    {
        int rollno;
        string name;
        string className;
        int semester;
        string branch;
        int[] marks = new int[5];
        string result;
        public Student(int rollno, string name, string className, int semester, string branch)
        {
            this.rollno = rollno;
            this.name = name;
            this.className = className;
            this.semester = semester;
            this.branch = branch;
        }
        public void GetMarks(int[] inputMarks)
        {
            if (inputMarks.Length == 5)
            {
                for(int i = 0; i < 5; i++)
                {
                    marks[i] = inputMarks[i];
                }
            }
        }
        public void DisplayResult()
        {
            double sum = 0;
            bool FailedSubject = false;
            foreach(int mark in marks)
            {
                if (mark < 35)
                {
                    FailedSubject = true;
                }
                sum += mark;
            }
            double avg = sum / 5.0;
            if (FailedSubject)
            {
                result = "Failed";
            }
            else if (avg < 50)
            {
                result = "Failed";
            }
            else
            {
                result = "Passed";
            }
        }
        public void DisplayData()
        {
            Console.WriteLine("Roll No: " + rollno);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Class: " + className);
            Console.WriteLine("Semester: " + semester);
            Console.WriteLine("Branch: " + branch);
            Console.WriteLine("Marks: " + string.Join(", ",marks));
            Console.WriteLine("Result: " + result);

        }
        public static void Show()
        {
            Student s = new Student(249, "jahnavi", "Btech", 2, "IT");
            s.GetMarks(new int[] { 98, 95, 89, 99, 85 });
            s.DisplayResult();
            s.DisplayData();
        }
        public static void Main()
        {
            Student.Show();
            Console.Read();
        }
    }
}
