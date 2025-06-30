using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }

    class EmployeeData
    {
        static List<Employee> employeeList = new List<Employee>();

        public static void Main()
        {
            int choice = 0;
            do
            {
                try
                {
                    Console.WriteLine("-----Employee Management Menu-----");
                    Console.WriteLine("1) Add New Employee");
                    Console.WriteLine("2) View All Employees");
                    Console.WriteLine("3) Search Employee by ID");
                    Console.WriteLine("4) Update Employee by ID");
                    Console.WriteLine("5) Delete Employee by ID");
                    Console.WriteLine("6) Exit");
                    Console.Write("Enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddEmployee();
                            break;
                        case 2:
                            ViewAllEmployees();
                            break;
                        case 3:
                            SearchEmployee();
                            break;
                        case 4:
                            UpdateEmployee();
                            break;
                        case 5:
                            DeleteEmployee();
                            break;
                        case 6:
                            Console.WriteLine("Exiting program...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input!");
                }

            } while (choice != 6);
        }

        public static void AddEmployee()
        {
            try
            {
                Employee emp = new Employee();
                Console.WriteLine("Enter ID: ");
                emp.ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Name: ");
                emp.Name = Console.ReadLine();
                Console.WriteLine("Enter Department: ");
                emp.Department = Console.ReadLine();
                Console.WriteLine("Enter Salary: ");
                emp.Salary = Convert.ToDouble(Console.ReadLine());
                employeeList.Add(emp);
                Console.WriteLine("Employee added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void ViewAllEmployees()
        {
            if (employeeList.Count == 0)
            {
                Console.WriteLine("No employee records found.");
                return;
            }

            Console.WriteLine("Employee Records:");
            foreach (var emp in employeeList)
            {
                Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
            }
        }

        public static void SearchEmployee()
        {
            Console.Write("Enter Employee ID to search: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp = employeeList.Find(e => e.ID == id);
            if (emp != null)
            {
                Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp = employeeList.Find(e => e.ID == id);
            if (emp != null)
            {
                Console.Write("Enter new Name: ");
                emp.Name = Console.ReadLine();
                Console.Write("Enter new Department: ");
                emp.Department = Console.ReadLine();
                Console.Write("Enter new Salary: ");
                emp.Salary = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Employee details updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee emp = employeeList.Find(e => e.ID == id);
            if (emp != null)
            {
                employeeList.Remove(emp);
                Console.WriteLine("Employee removed successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }
}


