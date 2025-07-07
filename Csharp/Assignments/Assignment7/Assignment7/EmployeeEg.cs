using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{

    //Third question
    //Create a list of employees with following property EmpId, EmpName, EmpCity, EmpSalary. Populate some data
    //Write a program for following requirement
    //a.To display all employees data
    //b.To display all employees data whose salary is greater than 45000
    //c.To display all employees data who belong to Bangalore Region
    //d.To display all employees data by their names is Ascending order
    class EmployeeEg
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }
    class Program
    {
        static void Main()
        {
            List<EmployeeEg> employees = new List<EmployeeEg>();

            Console.Write("Enter number of employees: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter details for Employee {i + 1}:");

                EmployeeEg emp = new EmployeeEg();

                Console.Write("Enter Employee ID: ");
                emp.EmpId = int.Parse(Console.ReadLine());

                Console.Write("Enter Employee Name: ");
                emp.EmpName = Console.ReadLine();

                Console.Write("Enter Employee City: ");
                emp.EmpCity = Console.ReadLine();

                Console.Write("Enter Employee Salary: ");
                emp.EmpSalary = double.Parse(Console.ReadLine());

                employees.Add(emp);
            }

            Console.WriteLine("1) All Employees:");
            foreach (var e in employees)
            {
                PrintEmployee(e);
            }

            Console.WriteLine("2) Employees with salary > 45000:");
            foreach (var e in employees.Where(e => e.EmpSalary > 45000))
            {
                PrintEmployee(e);
            }

            Console.WriteLine("3) Employees from Bangalore:");
            foreach (var e in employees.Where(e => e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase)))
            {
                PrintEmployee(e);
            }

            Console.WriteLine("4) Employees sorted by name:");
            foreach (var e in employees.OrderBy(e => e.EmpName))
            {
                PrintEmployee(e);
            }
            Console.Read();
        }

        static void PrintEmployee(EmployeeEg e)
        {
            Console.WriteLine($"ID: {e.EmpId}, Name: {e.EmpName}, City: {e.EmpCity}, Salary: {e.EmpSalary}");
        }
    }
   }
