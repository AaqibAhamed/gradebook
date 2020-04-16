using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        List<double> grades;
        
        public void AddGrade(double grade)
        {
           grades.Add(grade);
        }
    }
}