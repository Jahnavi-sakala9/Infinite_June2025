using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    //(Second question)
    //Create a class called Scholarship which has a function Public void Merit() that takes marks and fees as an input.
    //If the given mark is >= 70 and <=80, then calculate scholarship amount as 20% of the fees
    //If the given mark is > 80 and <=90, then calculate scholarship amount as 30% of the fees
    //If the given mark is >90, then calculate scholarship amount as 50% of the fees.
    //In all the cases return the Scholarship amount, else throw an user exception
    class InvalidMarkException : ApplicationException
    {
        public InvalidMarkException(string message) : base(message) 
        {
            
        }
    }
    class Scholarship
    {
        public static void Merit(double marks,double fees)
        {
            double scholarship = 0;
            if (marks > 70 && marks <= 80)
                scholarship = 0.2 * fees;
            else if (marks > 80 && marks <= 90)
                scholarship = 0.3 * fees;
            else
                throw new InvalidMarkException("Marks too low for scholarship");
            Console.WriteLine($"Scholarship awarded : {scholarship}");
        }
        public static void Main()
        {
            try
            {
                Console.WriteLine("Enter marks: ");
                double marks = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter fees: ");
                double fees = Convert.ToDouble(Console.ReadLine());
                Merit(marks, fees);
            }
            catch(InvalidMarkException ex)
            {
                Console.WriteLine("Message: " + ex.Message);
            }
            Console.Read();
        }
    }
}
