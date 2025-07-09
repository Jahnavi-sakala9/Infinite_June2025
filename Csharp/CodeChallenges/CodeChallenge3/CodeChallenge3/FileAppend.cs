using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeChallenge3
{
    //Third Question
    //Write a program in C# Sharp to append some text to an existing file. If file is not available, then create one in the same workspace.
    class FileAppend
    {
        static void Main()
        {
            string filePath = "SampleFile.txt";
            Console.Write("Enter the text to append into the file: ");
            string text = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine(text);
                }

                Console.WriteLine("Text successfully appended to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
            }
            Console.Read();
        }
    }
}

