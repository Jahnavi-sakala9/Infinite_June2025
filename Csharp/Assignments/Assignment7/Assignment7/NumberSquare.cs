using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    //First Question
    //Write a query that returns list of numbers and their squares only if square is greater than 20 
    //Example input[7, 2, 30]
    //Expected output
    //→ 7 - 49, 30 - 900

    class NumberSquare
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of elements: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[n];
            Console.WriteLine("Enter the numbers: ");
            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            var res = numbers.Select(m => new { number = m, Square = m * m }).Where(x => x.Square > 20);
            foreach(var item in res)
            {
                Console.WriteLine($"{item.number} square is{item.Square}");
            }
            Console.Read();
        }
    }
}
