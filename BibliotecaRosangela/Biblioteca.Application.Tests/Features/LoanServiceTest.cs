using Biblioteca.Applications.Features;
using Biblioteca.Common.Tests.Features;
using Biblioteca.Domain.Exceptions;
using Biblioteca.Domain.Features.Books;
using Biblioteca.Domain.Features.Loans;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Biblioteca.Application.Tests.Features
{
    [TestFixture]
    public class LoanServiceTest
    {
        private LoanService _service;
        private Mock<ILoanRepository> _mockRepository;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<ILoanRepository>();
            _service = new LoanService(_mockRepository.Object);
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_BookService_Add_ShouldBeOk()
        {
            var loan = LoanObjectMother.CreateValidLoan();

            _mockRepository
                .Setup(lr => lr.Add(loan))
                .Returns(new Loan { Id = 1 });

            var newBook = _service.Add(loan);

            _mockRepository.Verify(lr => lr.Add(loan));
            newBook.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(2)]
        public void Test_BookService_Get_ShouldBeOk()
        {
            var Id = 1;

            _mockRepository
                .Setup(lr => lr.Get(Id))
                .Returns(new Loan { Id = 1 });

            var newLoan = _service.Get(Id);

            _mockRepository.Verify(lr => lr.Get(Id));
            newLoan.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(3)]
        public void Test_BookService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(lr => lr.GetAll())
                .Returns(new List<Loan> { new Loan { Id = 1 } } );

            var loans = _service.GetAll();

            _mockRepository.Verify(lr => lr.GetAll());
            loans.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_BookService_GetBookFromLoan_ShouldBeOk()
        {
            var Id = 1;

            _mockRepository
                .Setup(lr => lr.GetBookFromLoan(Id))
                .Returns(new Book { Id = 1 } );

            var book = _service.GetBookFromLoan(Id);

            _mockRepository.Verify(lr => lr.GetBookFromLoan(Id));
            book.Id.Should().Be(Id);
        }

        [Test]
        [Order(5)]
        public void Test_BookService_Update_ShouldBeOk()
        {
            var loan = LoanObjectMother.CreateValidLoan();

            _mockRepository
                .Setup(lr => lr.Update(loan))
                .Returns(new Loan { Customer = "Squanchy" } );

            var newLoan = _service.Update(loan);

            _mockRepository.Verify(lr => lr.Update(loan));
            newLoan.Customer.Should().NotBeSameAs(loan.Customer);
        }

        [Test]
        [Order(6)]
        public void Test_BookService_Delete_ShouldBeOk()
        {
            var loan = LoanObjectMother.CreateValidLoan();

            _mockRepository
                .Setup(lr => lr.Delete(loan.Id));

            _service.Delete(loan);

            _mockRepository
                .Setup(lr => lr.Get(loan.Id));

            var loanDeleted = _service.Get(loan.Id);

            _mockRepository.Verify(lr => lr.Delete(loan.Id));
            loanDeleted.Should().BeNull();
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        [Order(7)]
        public void Test_BookService_GetInvalidId_ShouldBeOk()
        {
            var Id = -1;

            _mockRepository
                .Setup(lr => lr.Get(Id))
                .Throws<IdentifierUndefinedException>();

            Action action = () => _service.Get(Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(8)]
        public void Test_BookService_GetBookFromLoanInvalidId_ShouldBeOk()
        {
            var Id = -1;

            _mockRepository
                .Setup(lr => lr.GetBookFromLoan(Id))
                .Throws<IdentifierUndefinedException>();

            Action action = () => _service.GetBookFromLoan(Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(9)]
        public void Test_BookService_UpdateInvalidId_ShouldBeOk()
        {
            var loan = LoanObjectMother.CreateInvalidLoan_InvalidId();

            _mockRepository
                .Setup(lr => lr.Update(loan))
                .Throws<IdentifierUndefinedException>();

            Action action = () => _service.Update(loan);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(10)]
        public void Test_BookService_DeleteInvalidId_ShouldBeOk()
        {
            var loan = LoanObjectMother.CreateInvalidLoan_InvalidId();

            _mockRepository
                .Setup(lr => lr.Delete(loan.Id))
                .Throws<IdentifierUndefinedException>();

            Action action = () => _service.Delete(loan);
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
