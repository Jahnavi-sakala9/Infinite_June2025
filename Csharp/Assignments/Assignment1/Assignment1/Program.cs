using System;

namespace Assignment1
{
    class Program
    {
        public static void Firstquestion()
        {
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 == num2)
            {
                Console.WriteLine($"{num1} and {num2} are equal");
            }
            else
            {
                Console.WriteLine($"{num1} and {num2} are not equal");
            }
        }

        public static void Secondquestion()
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num > 0)
            {
                Console.WriteLine($"{num} is a positive number");
            }
            else if (num < 0)
            {
                Console.WriteLine($"{num} is a negative number");
            }
            else
            {
                Console.WriteLine("The number is zero");
            }
        }

        public static void Thirdquestion()
        {
            Console.WriteLine("Enter first number: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Operation(+,-,*,/): ");
            char operation = Convert.ToChar(Console.ReadLine());
            double result;
            switch (operation)
            {
                case '+':
                    result = n1 + n2;
                    Console.WriteLine($"{n1} + {n2} = {result}");
                    break;
                case '-':
                    result = n1 - n2;
                    Console.WriteLine($"{n1} - {n2} = {result}");
                    break;
                case '*':
                    result = n1 * n2;
                    Console.WriteLine($"{n1} * {n2} = {result}");
                    break;
                case '/':
                    if (n2 != 0)
                    {
                        result = n1 / n2;
                        Console.WriteLine($"{n1} / {n2} = {result}");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Operation");
                    break;
            }

        } 
        public static void Fourthquestion()
        {
            Console.WriteLine("Enter the number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{num} * {i} = {num * i}");
            }
        }
        public static void Fifthquestion()
        {
            Console.WriteLine("Enter first number: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            int result;
            if (n1 == n2)
            {
                result = 3 * (n1 + n2);
                Console.WriteLine(result);
            }
            else
            {
                result = n1 + n2;
                Console.WriteLine(result);
            }
        }

        static void Main(string[] args)
        {
            Firstquestion();
            Secondquestion();
            Thirdquestion();
            Fourthquestion();
            Fifthquestion();
            Console.Read();
        }
    }
}
