using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment6
{
    class FileCreationEg
    {
        //second question
        // Write a program in C# Sharp to create a file and write an array of strings to the file.
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            Console.WriteLine("Enter lines of text (press enter on an empty line to finish):");
            while (true)
            {
                string input = Console.ReadLine();
                //stop
                if (string.IsNullOrWhiteSpace(input))
                    break;
                lines.Add(input);
            }
            Console.WriteLine("Enter the filename:");
            string filename = Console.ReadLine();
            try
            {
                File.WriteAllLines(filename, lines);
                Console.WriteLine("File created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex.Message);
            }
            Console.Read();
        }
    }
}
