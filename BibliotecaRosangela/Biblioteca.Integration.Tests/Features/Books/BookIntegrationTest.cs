using Biblioteca.Applications.Features;
using Biblioteca.Common.Tests.Base;
using Biblioteca.Common.Tests.Features;
using Biblioteca.Domain.Features.Books;
using Biblioteca.Infra.Data.Features.Books;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Biblioteca.Integration.Tests.Features.Books
{
    [TestFixture]
    public class BookIntegrationTest
    {
        BookRepository _bookRepository;
        BookService _bookService;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _bookRepository = new BookRepository();
            _bookService = new BookService(_bookRepository);
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_BookIntegration_Add_ShouldBeOk()
        {
            var book = BookObjectMother.CreateValidBook();

            _bookService.Add(book);

            IList<Book> books = _bookService.GetAll();
            books.Count.Should().BeGreaterThan(0);
            books[1].Should().NotBeNull();
        }

        [Test]
        [Order(2)]
        public void Test_BookIntegrationData_Get_ShouldBeOk()
        {
            var Id = 1;

            var book = _bookService.Get(Id);
            book.Id.Should().Be(Id);
        }

        [Test]
        [Order(3)]
        public void Test_BookIntegrationData_GetAll_ShouldBeOk()
        {
            var books = _bookService.GetAll();
            books.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_BookIntegrationData_Update_ShouldBeOk()
        {
            var book = BookObjectMother.CreateValidBook();
            book.Title = "Java";

            var newBook = _bookService.Update(book);
            newBook.Equals(book).Should().BeTrue();
        }

        [Test]
        [Order(5)]
        public void Test_BookIntegrationData_Delete_ShouldBeOk()
        {
            var book = BookObjectMother.CreateValidBook();
            book = _bookService.Add(book);

            _bookService.Delete(book);

            var bookDeleted = _bookService.Get(book.Id);
            bookDeleted.Should().BeNull();
        }

        [Test]
        [Order(6)]
        public void Test_BookIntegrationData_IsTiedTo_ShouldBeOk()
        {
            var Id = 1;

            bool result = _bookService.IsTiedTo(Id);
            result.Should().Be(true);
        }
    }
}