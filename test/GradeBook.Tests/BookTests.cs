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
            book.AddGrade(85.3);//without this value also same average will come -maths magic 
            book.AddGrade(1001.1);//not going to include in average calaulation

            //actual
            var result = book.GetStatistics();


            //Assert

            Assert.Equal(85.6, result.Average, 1);//getting average in 1 decimal place 
            Assert.Equal(90.5, result.High);
            Assert.Equal(77.3, result.Low);
            Assert.Equal('A', result.Letter);


        }
    }
}
