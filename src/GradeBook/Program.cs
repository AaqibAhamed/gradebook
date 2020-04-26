using System;
using System.Collections.Generic;
using System.Dynamic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Aaqib's Grade Book");
            //book.AddGrade(84.5);
            //book.AddGrade(75.4);
            //book.AddGrade(96.2);
            //book.GetStatistics();

            while(true)
            {
                Console.WriteLine("Enter a grade or \"q\" to quit ");

                var input = Console.ReadLine();  
                            
                if(input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }

                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("");
                }



            }

            var stat = book.GetStatistics();

            Console.WriteLine($"The Highest Grade is {stat.High}");
            Console.WriteLine($"The Lowest Grade is {stat.Low}");
            Console.WriteLine($"The Average Grade is {stat.Average:N3}");
            Console.WriteLine($"The Final Grade is {stat.Letter}");

        }
    }
}
