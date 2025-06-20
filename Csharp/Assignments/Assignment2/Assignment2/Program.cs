using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    
    class Program
    {
        public static void FirstQuestion()
        {
            Console.Write("Enter First number: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Second number: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Before swapping N1={a} and N2={b}");
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"After swapping N1={a} and N2={b}");
        }
        public static void SecondQuestion()
        {
            Console.WriteLine("Enter a number: ");
            string number = Console.ReadLine();
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(number);
                }
                Console.WriteLine();
            }

        }
        
        public static void ThirdQuestion()
        {
           
            Console.WriteLine("Enter a number: ");
            int dayNo = Convert.ToInt32(Console.ReadLine());
            switch (dayNo)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Invalid Entry");
                    break;
            }

        }
        static void Main(string[] args)
        {
            FirstQuestion();
            SecondQuestion();
            ThirdQuestion();
            Console.Read();
        }
    }
}
