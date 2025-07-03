using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge2
{
    //Third Question
    //Exception
    class NegativeValueException : ApplicationException
    {
        public NegativeValueException(string message) : base(message)
        {

        }
    }
    //Main cLass
    class IntegerValueTest
    {
        public static void Main()
        {   
            try
            {
                Console.WriteLine("Enter the integer value");
                int a = Convert.ToInt32(Console.ReadLine());
                if (a < 0)
                {
                    throw new NegativeValueException("The value you entered was negative!");
                }
                else
                {
                    Console.WriteLine("The value is: " + a);
                }
            }
            catch (NegativeValueException exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.Read();
        }
        
    }
}
