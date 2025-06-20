using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class ArraysQuestions
    {
        //Avg, min, max
        public static void FirstQuestion()
        {
            Console.WriteLine("Enter the number of Elements: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            Console.WriteLine("Enter the Elements: ");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int sum = 0;
            int min = arr[0], max = arr[0];
            for(int i = 0; i < n; i++)
            {
                sum += arr[i];
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            float avg = sum / n;
            Console.WriteLine("Average value : " + avg);
            Console.WriteLine("Minimum value : " + min);
            Console.WriteLine("Maximum value: " + max);
        }

        //marks data
        public static void SecondQuestion()
        {
            int n = 10;
            int[] arr = new int[n];
            Console.WriteLine("Enter the 10 subject marks: ");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int total = 0;
            int min = arr[0], max = arr[0];
            for (int i = 0; i < n; i++)
            {
                total += arr[i];
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            float avg = total / n;
            Console.WriteLine("Total : " + total);
            Console.WriteLine("Average value : " + avg);
            Console.WriteLine("Minimum marks : " + min);
            Console.WriteLine("Maximum marks: " + max);

            Array.Sort(arr);
            Console.WriteLine("Marks in Ascending order :");
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Array.Reverse(arr);
            Console.WriteLine("Marks in descending order :");
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }

        }

        //Array copy
        public static void ThirdQuestion()
        {
            Console.WriteLine("Enter the number of elements: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            int[] copyarr = new int[n];
            for(int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                copyarr[i] = arr[i];
            }
            Console.WriteLine("Copied array: ");
            for(int i = 0; i < n; i++)
            {
                Console.Write(copyarr[i] + " ");
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
