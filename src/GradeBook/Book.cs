using System;
using System.Collections.Generic;
using System.IO;
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
    public interface IBook
    {
        string Name { get; }
        void AddGrade(double grade);
        
        event GradeAddedDelegate GradeAdded;
        Statistics GetStatistics();
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                if(grade <=100 && grade>=0)
                {
                    writer.WriteLine(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
              
            }
           
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;            
        }
    }

    public class InMemoryBook : Book
    {
        public const string CATEGORY = "Programming";

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        //Have to implement ...
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

        public override event GradeAddedDelegate GradeAdded;

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
                throw new ArgumentException($"Invalid {nameof(grade)} ");
            }

        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();          

            foreach (var grade in grades)
            {
                result.Add(grade);              
            }

            return result;
        }

        private List<double> grades;

        
    }
}
