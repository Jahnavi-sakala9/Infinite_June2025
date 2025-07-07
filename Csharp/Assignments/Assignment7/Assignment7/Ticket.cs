using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    //Fourth question
    // Create a class library with a function CalculateConcession()  that takes age as an input and calculates concession for travel as below:
    //If age <= 5 then “Little Champs - Free Ticket” should be displayed
    //If age > 60 then calculate 30% concession on the totalfare(Which is a constant Eg:500/-) and Display “ Senior Citizen” + Calculated Fare
    //Else “Print Ticket Booked” + Fare.
    //Create a Console application with a Class called Program which has TotalFare as Constant, Name, Age.Accept Name, Age from the user and call the CalculateConcession() function to test the Classlibrary functionality
    class Ticket
    {
        public void CalculateConcession(string name, int age, double fare)
        {
            if (age <= 5)
            {
                Console.WriteLine("Little Champs - Free Ticket");
            }
            else if (age >= 60)
            {
                double discountedFare = fare * 0.7;
                Console.WriteLine($"Senior Citizen - {name}, Fare: {discountedFare}");
            }
            else
            {
                Console.WriteLine($"Ticket Booked - {name}, Fare: {fare}");
            }
        }
        static void Main()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Total Fare: ");
            double fare = double.Parse(Console.ReadLine());

            Ticket ticket = new Ticket();
            ticket.CalculateConcession(name, age, fare);
            Console.Read();
        }

    }
}
