using Biblioteca.Common.Tests.Base;
using Biblioteca.Common.Tests.Features;
using Biblioteca.Domain.Exceptions;
using Biblioteca.Domain.Features.Loans;
using Biblioteca.Infra.Data.Features.Loans;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Biblioteca.Infra.Data.Tests.Features.Loans
{
    [TestFixture]
    public class LoanIntegrationDataTest
    {
        private ILoanRepository _repository;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new LoanRepository();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_LoanIntegrationData_Add_ShouldBeOk()
        {
            var loan = LoanObjectMother.CreateValidLoan();

            var newLoan = _repository.Add(loan);
            newLoan.Id.Should().Be(loan.Id);
        }

        [Test]
        [Order(2)]
        public void Test_LoanIntegrationData_Get_ShouldBeOk()
        {
            var loanId = 1;

            var loan = _repository.Get(loanId);
            loan.Id.Should().Be(loanId);
        }

        [Test]
        [Order(3)]
        public void Test_LoanIntegrationData_GetAll_ShouldBeOk()
        {
            var loans = _repository.GetAll();
            loans.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_LoanIntegrationData_GetBookFromLoan_ShouldBeOk()
        {
            var loanId = 1;

            var book = _repository.GetBookFromLoan(loanId);
            book.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(5)]
        public void Test_LoanIntegrationData_GetByBook_ShouldBeOk()
        {
            var bookId = 1;

            var loan = _repository.GetByBook(bookId);
            loan.Should().NotBeNull();
        }

        [Test]
        [Order(6)]
        public void Test_LoanIntegrationData_Update_ShouldBeOk()
        {
            var loan = LoanObjectMother.CreateValidLoan();
            loan.Customer = "Squanchy";

            var newLoan = _repository.Update(loan);
            newLoan.Equals(loan).Should().BeTrue();
        }

        [Test]
        [Order(7)]
        public void Test_LoanIntegrationData_Delete_ShouldBeOk()
        {
            var loanId = 1;

            _repository.Delete(loanId);

            var loanDeleted = _repository.Get(loanId);
            loanDeleted.Should().BeNull();
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        [Order(8)]
        public void Test_LoanIntegrationData_GetInvalidId_ShouldFail()
        {
            var loanId = -1;

            Action action = () => _repository.Get(loanId);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(9)]
        public void Test_LoanIntegrationData_GetBookFromLoanInvalidId_ShouldFail()
        {
            var loanId = -1;

            Action action = () => _repository.GetBookFromLoan(loanId);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(10)]
        public void Test_LoanIntegrationData_GetByBookInvalidId_ShouldFail()
        {
            var bookId = -1;

            Action action = () => _repository.GetByBook(bookId);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(11)]
        public void Test_LoanIntegrationData_DeleteInvalidId_ShouldFail()
        {
            var loanId = -1;

            Action action = () => _repository.Delete(loanId);
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
