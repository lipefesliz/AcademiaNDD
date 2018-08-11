using Biblioteca.Applications.Features;
using Biblioteca.Common.Tests.Features;
using Biblioteca.Domain.Exceptions;
using Biblioteca.Domain.Features.Books;
using Biblioteca.Domain.Features.Books.Exceptions;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Biblioteca.Application.Tests.Features
{
    [TestFixture]
    public class BookServiceTest
    {
        private BookService _service;
        private Mock<IBookRepository> _mockRepository;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IBookRepository>();
            _service = new BookService(_mockRepository.Object);
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_BookService_Add_ShouldBeOk()
        {
            var book = BookObjectMother.CreateValidBook();

            _mockRepository
                .Setup(br => br.Add(book))
                .Returns(new Book { Id = 1 });

            var newBook = _service.Add(book);

            _mockRepository.Verify(br => br.Add(book));
            newBook.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(2)]
        public void Test_BookService_Get_ShouldBeOk()
        {
            var Id = 1;

            _mockRepository
                .Setup(br => br.Get(Id))
                .Returns(new Book { Id = 1 });

            var book = _service.Get(Id);

            _mockRepository.Verify(br => br.Get(Id));
            book.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(3)]
        public void Test_BookService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(br => br.GetAll())
                .Returns(new List<Book> { new Book { Id = 1 } });

            var books = _service.GetAll();

            _mockRepository.Verify(br => br.GetAll());
            books.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_BookService_Update_ShouldBeOk()
        {
            var book = BookObjectMother.CreateValidBook();

            _mockRepository
                .Setup(br => br.GetByTitle(book.Title));

            _mockRepository
                .Setup(br => br.Update(book))
                .Returns( new Book { Id = 1, Title = "Python" });

            var newBook = _service.Update(book);

            _mockRepository.Verify(br => br.Update(book));
            newBook.Title.Should().NotBeSameAs(book.Title);
        }

        [Test]
        [Order(5)]
        public void Test_BookService_Delete_ShouldBeOk()
        {
            var book = BookObjectMother.CreateValidBook();

            _mockRepository
                .Setup(br => br.Delete(book.Id));

            _service.Delete(book);

            _mockRepository
                .Setup(br => br.Get(book.Id));

            var deleted = _service.Get(book.Id);

            _mockRepository.Verify(br => br.Delete(book.Id));
            deleted.Should().BeNull();
        }

        [Test]
        [Order(6)]
        public void Test_BookService_IsTiedTo_ShouldBeOk()
        {
            var Id = 1;

            _mockRepository
                .Setup(br => br.IsTiedTo(Id))
                .Returns(false);

            bool result = _service.IsTiedTo(Id);
            result.Should().Be(false);
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(7)]
        public void Test_BookService_AddDuplicatedTitle_ShouldFail()
        {
            var book = BookObjectMother.CreateValidBook();

            _mockRepository
                .Setup(br => br.Exist(book.Title))
                .Returns(true);

            Action action = () => _service.Add(book);
            action.Should().Throw<DuplicatedTitleException>();
        }

        [Test]
        [Order(8)]
        public void Test_BookService_GetUndefinedId_ShouldFail()
        {
            var Id = -1;

            _mockRepository
                .Setup(br => br.Get(Id))
                .Throws<IdentifierUndefinedException>();

            Action action = () => _service.Get(Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(9)]
        public void Test_BookService_UpdateDuplicatedTitle_ShouldFail()
        {
            var book = BookObjectMother.CreateValidBook();

            _mockRepository
                .Setup(br => br.GetByTitle(book.Title))
                .Returns(new Book { Id = 2, Title = "C# - Use a Cabeca" });

            _mockRepository
                .Setup(br => br.Update(book))
                .Throws<DuplicatedTitleException>();

            Action action = () =>  _service.Update(book);
            action.Should().Throw<DuplicatedTitleException>();
        }

        [Test]
        [Order(10)]
        public void Test_BookService_DeleteUndefinedId_ShouldFail()
        {
            var book = BookObjectMother.CreateInvalidBook_InvalidId();

            _mockRepository
                .Setup(br => br.Delete(book.Id))
                .Throws<IdentifierUndefinedException>();

            Action action = () => _service.Delete(book);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(11)]
        public void Test_BookService_DeleteItemTiedTo_ShouldFail()
        {
            var book = BookObjectMother.CreateValidBook();

            _mockRepository
                .Setup(br => br.IsTiedTo(book.Id))
                .Returns(true);

            _mockRepository
                .Setup(br => br.Delete(book.Id))
                .Throws<ItemTiedToException>();

            Action action = () => _service.Delete(book);
            action.Should().Throw<ItemTiedToException>();
        }

        [Test]
        [Order(12)]
        public void Test_BookService_IsTiedTo_ShouldFail()
        {
            var Id = -1;

            _mockRepository
                .Setup(br => br.IsTiedTo(Id))
                .Throws<IdentifierUndefinedException>();

            Action action = () => _service.IsTiedTo(Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
