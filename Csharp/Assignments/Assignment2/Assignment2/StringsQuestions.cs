using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class StringsQuestions
    {
        //length of the string
        public static void FirstQuestion()
        {
            Console.WriteLine("Enter the string: ");
            string str = Console.ReadLine();
            Console.WriteLine("Length of the string is  " + str.Length);
        }

        //string reverse
        public static void SecondQuestion()
        {
            Console.WriteLine("Enter a word: ");
            string Word = Console.ReadLine();
            string reversedWord = "";
            for(int i = Word.Length - 1; i >= 0; i--)
            {
                reversedWord += Word[i];
            }
            Console.WriteLine("Reversed Word: " + reversedWord);
        }
        //string comparision
        public static void ThirdQuestion()
        {
            Console.WriteLine("Enter the First word: ");
            string Word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second word: ");
            string Word2 = Console.ReadLine();
            if (Word1.Equals(Word2)){
                Console.WriteLine("Both words are same");
            }
            else
            {
                Console.WriteLine("Both words are not same");
            }
        }
        public static void Main(String[] args)
        {
            FirstQuestion();
            SecondQuestion();
            ThirdQuestion();
            Console.Read();
        }
    }
}
