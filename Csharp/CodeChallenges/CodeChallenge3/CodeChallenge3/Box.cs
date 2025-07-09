using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    //Second Question
    //Write a class Box that has Length and breadth as its members.
    //Write a function that adds 2 box objects and stores in the 3rd. Display the 3rd object details. Create a Test class to execute the above.
    class Box
    {
        public int length;
        public int breadth;
        
        //Operator Overloading
        public static Box operator +(Box box1, Box box2)
        {
            Box temp = new Box();
            temp.length = box1.length + box2.length;
            temp.breadth = box1.breadth + box2.breadth;
            return temp;
        }

        static void Main()
        {
            Console.WriteLine("Enter the length of Box1: ");
            int l1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Breadth of Box1: ");
            int bd1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the length of Box2: ");
            int l2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Breadth of Box2: ");
            int bd2 = Convert.ToInt32(Console.ReadLine());
            Box b1 = new Box();
            b1.length = l1;
            b1.breadth = bd1;

            Box b2 = new Box();
            b2.length = l2;
            b2.breadth = bd2;

            Box b3 = b1 + b2;  
            Console.WriteLine($"The overall Length is {b3.length} and breadth is {b3.breadth}");
            Console.Read();

        }
    }
}

