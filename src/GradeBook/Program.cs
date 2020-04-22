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
            book.ShowStatistics();


           



        }
    }
}
