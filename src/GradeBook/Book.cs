using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string Name;

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(75);
                    break;
                case 'B':
                    AddGrade(65);
                    break;
                case 'C':
                    AddGrade(50);
                    break;
                case 'D':
                    AddGrade(40);
                    break;
                default:
                    AddGrade(0);
                    break;

            }

        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }

            else
            {
                Console.WriteLine("Invalid Grade !");
            }

        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 75.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 65.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 50.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 40.0:
                    result.Letter = 'A';
                    break;
                default:
                    result.Letter = 'F';
                    break;

            }

            return result;

        }
    }
}
