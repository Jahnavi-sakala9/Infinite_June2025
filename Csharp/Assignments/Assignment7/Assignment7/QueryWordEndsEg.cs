using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class QueryWordEndsEg
    {
        //Second Question
        //Write a query that returns words starting with letter 'a' and ending with letter 'm'.
        //Expected input and output "mum", "amsterdam", "bloom" → "amsterdam"
        public static void Main()
        {
            Console.WriteLine("Enter number of words: ");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] words = new string[n];
            Console.WriteLine("Enter the words: ");
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = Console.ReadLine();
            }
            var res = words.Where(w => w.StartsWith("a", StringComparison.OrdinalIgnoreCase) && w.EndsWith("m",StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("The words are: ");
            foreach (var word in res)
            {
                Console.WriteLine(word);
            }
            Console.Read();
        }
    }
}
