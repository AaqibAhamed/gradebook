using System;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string message);
    public class TypeTest
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanLogManyMethod()
        {
            WriteLogDelegate log = writelogMethod;

            log += writelogMethod;
            log += countLogMethod;

            var result = log("Wel Come !");
            Assert.Equal(3, count);
        }

        private string countLogMethod(string message)
        {
            count++;
            return message.ToUpper();
        }

        private string writelogMethod(string message)
        {
            count++;
            return message;

        }

        [Fact]
        public void StringBehaveLikeValueType()
        {
            string name = "Aaqib";

            var upper = MakeUpperCase(name);

            Assert.Equal("AAQIB", upper);
            Assert.Equal("Aaqib", name);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypeCanPassByRef()
        {
            int x = GetInt();
            SetInt(ref x);

            Assert.Equal(28, x);
        }

        private void SetInt(ref int z)
        {
            z = 28;
        }
        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            int x = GetInt();
            SetInt(x);

            Assert.Equal(8, x);
        }

        private void SetInt(int x) // refernce type 
        {
            x = 28;
        }

        private int GetInt()
        {
            return 8;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            //Assert
            Assert.Equal("New Name", book1.Name);

        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);

        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            //Assert
            Assert.Equal("Book 1", book1.Name);


        }

        private void GetBookSetName( InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameForReference()
        {
            var book1 = GetBook("Book 1");
            SetBookName(book1, "New Name");

            var book2 = GetBook("Book 2");

            //Assert
            Assert.Equal("New Name", book1.Name);
            Assert.Equal("Book 2", book2.Name);

        }

        private void SetBookName(InMemoryBook book, string name)
        {
            book.Name = name;

        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

        [Fact]
        public void GetBookReturnsDifferentObject()
        {


            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //Assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);

        }

        [Fact]
        public void TwoVariableReferenceOneObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            //Assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book2, book1));
        }

    }
}
