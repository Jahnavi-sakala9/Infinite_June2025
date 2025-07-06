using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment6
{
    //Third Question
    // Write a program in C# Sharp to count the number of lines in a file.
    class FileLinesCountEg
    {
        public static void Main()
        {
            Console.WriteLine("Enter the file name to read: ");
            string filename = Console.ReadLine();
            try
            {
                string[] lines = File.ReadAllLines(filename);
                int linecount = lines.Length;
                Console.WriteLine($"The file {filename} has {linecount} lines.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The specified file was not found");
            }
            Console.Read();
        }
    }
}
