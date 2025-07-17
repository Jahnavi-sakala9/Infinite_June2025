using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCsharpCodeChallenge
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Employee> empList = new List<Employee>();

            Console.Write("How many employees do you want to enter? ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nEnter details for Employee #{i + 1}:");

                Employee emp = new Employee();

                Console.Write("Employee ID: ");
                emp.EmployeeID = int.Parse(Console.ReadLine());

                Console.Write("First Name: ");
                emp.FirstName = Console.ReadLine();

                Console.Write("Last Name: ");
                emp.LastName = Console.ReadLine();

                Console.Write("Title: ");
                emp.Title = Console.ReadLine();

                Console.Write("Date of Birth: ");
                emp.DOB = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Date of Joining: ");
                emp.DOJ = Convert.ToDateTime(Console.ReadLine());

                Console.Write("City: ");
                emp.City = Console.ReadLine();

                empList.Add(emp);
            }
            Console.WriteLine("Choose a query to display employees:");
            Console.WriteLine("1. All Employees");
            Console.WriteLine("2. Employees not in Mumbai");
            Console.WriteLine("3. Employees with Title 'AsstManager'");
            Console.WriteLine("4. Employees whose last name starts with 'S'");
            Console.Write("Enter your choice (1-4): ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("All Employees:");
                    foreach (var emp in empList)
                        PrintEmployee(emp);
                    break;

                case 2:
                    Console.WriteLine("Employees not in Mumbai:");
                    var notInMumbai = empList.Where(e => e.City != "Mumbai");
                    foreach (var emp in notInMumbai)
                        PrintEmployee(emp);
                    break;

                case 3:
                    Console.WriteLine("Employees with Title 'AsstManager':");
                    var asstManagers = empList.Where(e => e.Title == "AsstManager");
                    foreach (var emp in asstManagers)
                        PrintEmployee(emp);
                    break;

                case 4:
                    Console.WriteLine("Employees whose last name starts with 'S':");
                    var lastNameStartsWithS = empList.Where(e => e.LastName.StartsWith("S"));
                    foreach (var emp in lastNameStartsWithS)
                        PrintEmployee(emp);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.Read();
        }

        static void PrintEmployee(Employee emp)
        {
            Console.WriteLine($"{emp.EmployeeID}, {emp.FirstName} {emp.LastName}, {emp.Title}, DOB: {emp.DOB:dd-MM-yyyy}, DOJ: {emp.DOJ:dd-MM-yyyy}, City: {emp.City}");
        }
    }
}

   






