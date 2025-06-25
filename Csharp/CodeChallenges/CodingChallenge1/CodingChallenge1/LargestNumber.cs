using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge1
{
    class LargestNumber
    {
        public static int LargestNo(int a, int b, int c)
        {
            if (a > b && a > c)
            {
                return a;
            }else if (b > a && b > c)
            {
                return b;
            }
            else 
            {
                return c;
            }
           
        }
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter the First value");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Second value");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Third value");
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The largest value is: "+LargestNo(a, b, c));
            Console.Read();
        }
    }
}
