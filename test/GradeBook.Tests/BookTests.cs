using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void CalaculateAnAverageGrade()
        {
            //arrange
           var book = new Book("");

           book.AddGrade(89.1);
           book.AddGrade(90.5);
           book.AddGrade(77.3);

           //actual
           var result = book.GetStatistics();


            //Assert

            Assert.Equal(85.6, result.Average,1);//getting average in 1 decimal place 
            Assert.Equal(90.5, result.High);
            Assert.Equal(77.3, result.Low);

           
            



        }
    }
}
