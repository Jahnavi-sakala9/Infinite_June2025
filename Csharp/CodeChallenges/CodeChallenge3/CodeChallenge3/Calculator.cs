using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    //Fourth Question
    //Write a console program that uses delegate object as an argument to call Calculator Functionalities like 1. Addition, 2. Subtraction and 3. Multiplication by taking 2 integers and returning the output to the user.
    //You should display all the return values accordingly.
    class Calculator
    {
        public static int Add(int a, int b) => a + b;
        public static int Subtract(int a, int b) => a - b;
        public static int Multiply(int a, int b) => a * b;
    }
    class CalcTest
    {
        delegate int CalcDelegate(int x, int y);
        static void Main()
        {
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            CalcDelegate operation;

            // Addition
            operation = Calculator.Add;
            Console.WriteLine($"Addition of {num1} and {num2} is {operation(num1, num2)}");

            // Subtraction
            operation = Calculator.Subtract;
            Console.WriteLine($"Subtraction of {num1} and {num2} is {operation(num1, num2)}");

            // Multiplication
            operation = Calculator.Multiply;
            Console.WriteLine($"Multiplication of {num1} and {num2} is {operation(num1, num2)}");
            Console.Read();
        }
    }
}
