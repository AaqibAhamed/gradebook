using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades ;
        private string name;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            double result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade  = double.MaxValue;

            foreach (var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }

            result /= grades.Count;

            Console.WriteLine($"The Highest Grade is {highGrade}");
            Console.WriteLine($"The Lowest Grade is {lowGrade}");
            Console.WriteLine($"The Average Grade is {result:N3}");

        }
    }
}
