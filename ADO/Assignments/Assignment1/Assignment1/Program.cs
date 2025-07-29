using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
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
        static void DisplayEmployees(string title, IEnumerable<Employee> employees, string extraInfo = "")
        {
            Console.WriteLine($"\n{title}");
            foreach (var emp in employees)
            {
                string info = $"{emp.FirstName} {emp.LastName}";
                if (!string.IsNullOrEmpty(extraInfo))
                {
                    switch (extraInfo)
                    {
                        case "DOJ":
                            info += $" - DOJ: {emp.DOJ.ToShortDateString()}";
                            break;
                        case "DOB":
                            info += $" - DOB: {emp.DOB.ToShortDateString()}";
                            break;
                        case "Title":
                            info += $" - Title: {emp.Title}";
                            break;
                    }
                }
                Console.WriteLine(info);
            }
        }

        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("16/11/1984"), DOJ = DateTime.Parse("8/6/2011"), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("20/08/1984"), DOJ = DateTime.Parse("7/7/2012"), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("14/11/1987"), DOJ = DateTime.Parse("12/4/2015"), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("3/6/1990"), DOJ = DateTime.Parse("2/2/2016"), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("8/3/1991"), DOJ = DateTime.Parse("2/2/2016"), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("7/11/1989"), DOJ = DateTime.Parse("8/8/2014"), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.Parse("2/12/1989"), DOJ = DateTime.Parse("1/6/2015"), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.Parse("11/11/1993"), DOJ = DateTime.Parse("6/11/2014"), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.Parse("12/8/1992"), DOJ = DateTime.Parse("3/12/2014"), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.Parse("12/4/1991"), DOJ = DateTime.Parse("2/1/2016"), City = "Pune" }
            };

            DisplayEmployees("1. Employees who joined before 1/1/2015:", empList.Where(e => e.DOJ < new DateTime(2015, 1, 1)), "DOJ");

            DisplayEmployees("2. Employees born after 1/1/1990:", empList.Where(e => e.DOB > new DateTime(1990, 1, 1)), "DOB");

            DisplayEmployees("3. Employees with title Consultant or Associate:", empList.Where(e => e.Title == "Consultant" || e.Title == "Associate"), "Title");

            Console.WriteLine("\n4. Total number of employees: " + empList.Count);

            Console.WriteLine("\n5. Number of employees from Chennai: " + empList.Count(e => e.City == "Chennai"));

            Console.WriteLine("\n6. Highest Employee ID: " + empList.Max(e => e.EmployeeID));

            Console.WriteLine("\n7. Employees who joined after 1/1/2015: " + empList.Count(e => e.DOJ > new DateTime(2015, 1, 1)));

            Console.WriteLine("\n8. Employees whose designation is not 'Associate': " + empList.Count(e => e.Title != "Associate"));

            Console.WriteLine("\n9. Employee count by City:");
            foreach (var group in empList.GroupBy(e => e.City))
                Console.WriteLine($"{group.Key} - {group.Count()}");

            Console.WriteLine("\n10. Employee count by City and Title:");
            foreach (var group in empList.GroupBy(e => new { e.City, e.Title }))
                Console.WriteLine($"{group.Key.City}, {group.Key.Title} - {group.Count()}");

            DateTime maxDob = empList.Max(e => e.DOB);
            DisplayEmployees("11. Youngest employee(s):", empList.Where(e => e.DOB == maxDob), "DOB");

            Console.Read();
        }
    }
}
