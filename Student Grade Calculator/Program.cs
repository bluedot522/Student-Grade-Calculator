using System;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using static System.Console;
using System.Text.RegularExpressions;

namespace StudentGradeCalculator
{
    class GradeCalc
    {
        static void Main()
        {
            string studentName = GetName();
            studentName = ValidateName(studentName);
            decimal finalAverage = GetScores();
            char letterGrade = GetLetterGrade(finalAverage);
            DisplayResults(studentName, finalAverage, letterGrade);
        }

        static string GetName()
        {
            WriteLine("Welcome! Please enter student name to begin. >> ");
            string name = Console.ReadLine();
            return name;
        }
        static string ValidateName(string name)
        {

            while (!Regex.IsMatch(name, @"[a-zA-Z\s]$"))
            {
                WriteLine("Please enter a name. (Letters only.)");
                name = Console.ReadLine();
            }
            return name;
        }
        static decimal GetScores()
        {
            string scoreString = "";
            int scoreCount = 0;
            decimal totalScore = 0.00m;
            WriteLine("Enter a score or X to quit.");
            string input = ReadLine();
            while (input!= "X" && input!= "x")
            {
                // Validate Scores
                if (Decimal.TryParse(input, out decimal value))
                {
                    decimal score = Convert.ToDecimal(input);
                    if (score <= 100.0m && score >= 0.0m)
                    { totalScore += score;
                        scoreCount += 1;
                        scoreString += Convert.ToString(score) + " ";
                    }
                    else
                    {
                        WriteLine("Please enter a number between 0 and 100.");
                        WriteLine(" ");
                    }
                }
                else
                {
                    WriteLine("Please enter a number.");
                    WriteLine(" ");
                }
                WriteLine("Enter a score or X to quit.");
                input = ReadLine();

            }
            if (scoreCount > 0)
            { WriteLine("Scores entered: " + scoreString); }

            else 
            { WriteLine("Scores entered: 0"); }

            return CalculateAverage(totalScore, scoreCount);
        }

        static decimal CalculateAverage(decimal totalScore, int scoreCount)
        {
            decimal finalAverage;
            if (scoreCount == 0)
            {
                finalAverage = 0;
            }
            else
            { finalAverage = totalScore / scoreCount; }
            return finalAverage;
        }
        static char GetLetterGrade(decimal finalAverage)
        {
            char letterGrade;
            if (finalAverage >= 90)
            {
                letterGrade = 'A';
            }
            else if (finalAverage < 90 && finalAverage >= 80)
            {
                letterGrade = 'B';
            }
            else if (finalAverage < 80 && finalAverage >= 70)
            {
                letterGrade = 'C';
            }
            else if (finalAverage < 70 && finalAverage >= 60)
            {
                letterGrade = 'D';
            }
            else
            { letterGrade = 'F'; }
            return letterGrade;
        }
      
        static void DisplayResults(string name, decimal average, char letter)
        {
            WriteLine("{0}'s grade is an average of {1:F2}% and a grade of {2}.", name, average, letter);
        }

       
        }  
        
}

