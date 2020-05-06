using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs eventArgs);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public abstract class Book : NamedObject
    {
        public Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);
    }

    public class InMemoryBook : Book
    {

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
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

        public event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }

            else
            {
                //Console.WriteLine("Invalid Grade !");
                throw new ArgumentException($"Invalid {nameof(grade)} ");
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

        private List<double> grades;

        public const string CATEGORY = "Programming";
    }
}
