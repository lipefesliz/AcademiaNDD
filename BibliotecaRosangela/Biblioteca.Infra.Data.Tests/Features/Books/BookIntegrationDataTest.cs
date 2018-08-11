using Biblioteca.Common.Tests.Base;
using Biblioteca.Common.Tests.Features;
using Biblioteca.Domain.Exceptions;
using Biblioteca.Domain.Features.Books;
using Biblioteca.Infra.Data.Features.Books;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Biblioteca.Infra.Data.Tests.Features.Books
{
    [TestFixture]
    public class BookIntegrationDataTest
    {
        private IBookRepository _repository;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new BookRepository();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_BookIntegrationData_Add_ShouldBeOk()
        {
            var book = BookObjectMother.CreateValidBook();

            var newBook = _repository.Add(book);
            newBook.Id.Should().Be(book.Id);
        }

        [Test]
        [Order(2)]
        public void Test_BookIntegrationData_Get_ShouldBeOk()
        {
            var Id = 1;

            var book = _repository.Get(Id);
            book.Id.Should().Be(Id);
        }

        [Test]
        [Order(3)]
        public void Test_BookIntegrationData_GetAll_ShouldBeOk()
        {
            var books = _repository.GetAll();
            books.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_BookIntegrationData_GetByTitle_ShouldBeOk()
        {
            var title = "Python";

            var book = _repository.GetByTitle(title);
            book.Title.Should().Be(title);
        }

        [Test]
        [Order(5)]
        public void Test_BookIntegrationData_Update_ShouldBeOk()
        {
            var book = BookObjectMother.CreateValidBook();
            book.Title = "Java";

            var newBook = _repository.Update(book);
            newBook.Equals(book).Should().BeTrue();
        }

        [Test]
        [Order(6)]
        public void Test_BookIntegrationData_Delete_ShouldBeOk()
        {
            var book = BookObjectMother.CreateValidBook();
            book = _repository.Add(book);

            _repository.Delete(book.Id);

            var bookDeleted = _repository.Get(book.Id);
            bookDeleted.Should().BeNull();
        }

        [Test]
        [Order(7)]
        public void Test_BookIntegrationData_Exist_ShouldBeOk()
        {
            bool result = _repository.Exist("Python");
            result.Should().Be(true);
        }

        [Test]
        [Order(8)]
        public void Test_BookIntegrationData_IsTiedTo_ShouldBeOk()
        {
            var Id = 1;

            bool result = _repository.IsTiedTo(Id);
            result.Should().Be(true);
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        [Order(9)]
        public void Test_BookIntegrationData_GetInvalidId_ShouldFail()
        {
            var Id = -1;

            Action action = () => _repository.Get(Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(10)]
        public void Test_BookIntegrationData_DeleteInvalidId_ShouldBeOk()
        {
            var Id = -1;

            Action action = () => _repository.Delete(Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(11)]
        public void Test_BookIntegrationData_DeleteItemTiedTo_ShouldBeOk()
        {
            var Id = 1;

            Action action = () => _repository.Delete(Id);
            action.Should().Throw<ItemTiedToException>();
        }

        [Test]
        [Order(12)]
        public void Test_BookIntegrationData_IsTiedToInvalidId_ShouldFail()
        {
            var Id = -1;

            Action action = () => _repository.IsTiedTo(Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
