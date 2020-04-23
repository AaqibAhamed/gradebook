using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //arrange
           var book = new Book("");

           book.AddGrade(85.7);
           book.AddGrade(72.5);

           //actual
           book.ShowStatistics();



        }
    }
}
