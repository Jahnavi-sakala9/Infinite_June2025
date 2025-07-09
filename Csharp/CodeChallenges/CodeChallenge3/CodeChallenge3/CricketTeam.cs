using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    //First Question
    //Write a program to find the Sum and the Average points scored by the teams in the IPL.
    //Create a Class called CricketTeam that has a function called Pointscalculation(int no_of_matches) that takes no.of matches as input and accepts that many scores from the user.
    //The function should then return the Count of Matches, Average and Sum of the scores.
    class CricketTeam
    {
        public static void PointsCalculation(int no_of_matches)
        {
            int[] scores = new int[no_of_matches];
            int sum = 0;
            Console.WriteLine("Enter the Scores: ");
            for (int i = 0; i < no_of_matches; i++)
            {
                Console.WriteLine($"Match {i + 1} : ");
                scores[i] = Convert.ToInt32(Console.ReadLine());
                sum += scores[i];
            }
            double average = (double)sum / no_of_matches;
            Console.WriteLine("Total Matches: " + no_of_matches);
            Console.WriteLine("Sum of scores: " + sum);
            Console.WriteLine("Average Score: " + average);
        }
        public static void Main()
        {
            Console.WriteLine("Enter number of matches played: ");
            int matchesCount = Convert.ToInt32(Console.ReadLine());
            PointsCalculation(matchesCount);
            Console.Read();
        }
    }
}
