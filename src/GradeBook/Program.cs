using System;
using System.Collections.Generic;
using System.Dynamic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Aaqib's GradeBook");
            book.AddGrade(84.5);
            book.AddGrade(75.4);
            book.AddGrade(96.2);
            book.GetStatistics();

            var stat =  new Statistics();


            Console.WriteLine($"The Highest Grade is {stat.High}");
            Console.WriteLine($"The Lowest Grade is {stat.Low}");
            Console.WriteLine($"The Average Grade is {stat.Average:N3}");


           



        }
    }
}
