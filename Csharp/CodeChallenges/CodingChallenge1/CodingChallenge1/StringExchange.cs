using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge1
{
    class StringExchange
    {
        public static string swapCharacters(string str)
        {
            if (str.Length < 2)
                return str;
            char first = str[0];
            char last = str[str.Length-1];
            return last + str.Substring(1, str.Length - 2) + first;
        }
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter the string: ");
            string str = Console.ReadLine();
            Console.WriteLine(swapCharacters(str));
            Console.Read();
        }
    }
}
