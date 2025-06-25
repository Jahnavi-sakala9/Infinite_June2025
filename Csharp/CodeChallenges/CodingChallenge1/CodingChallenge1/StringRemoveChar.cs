using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge1
{
    class StringRemoveChar
    {
        public static string RemoveCharacter(string s, int pos)
        {
            return s.Remove(pos, 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string str = Console.ReadLine();
            Console.WriteLine("Enter the position: ");
            int position = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(RemoveCharacter(str, position));
            Console.Read();
        }
    }
}
