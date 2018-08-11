using Biblioteca.Applications.Features;
using Biblioteca.Common.Tests.Base;
using Biblioteca.Common.Tests.Features;
using Biblioteca.Domain.Features.Loans;
using Biblioteca.Infra.Data.Features.Loans;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Biblioteca.Integration.Tests.Features.Loans
{
    [TestFixture]
    public class LoanIntegrationTest
    {
        LoanRepository _loanRepository;
        LoanService _loanService;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _loanRepository = new LoanRepository();
            _loanService = new LoanService(_loanRepository);
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_LoanIntegration_Add_ShouldBeOk()
        {
            var loan = LoanObjectMother.CreateValidLoan();

            _loanService.Add(loan);

            IList<Loan> loans = _loanService.GetAll();
            loans.Count.Should().BeGreaterThan(0);
            loans[1].Should().NotBeNull();
        }

        [Test]
        [Order(2)]
        public void Test_LoanIntegration_Get_ShouldBeOk()
        {
            var loanId = 1;

            var loan = _loanService.Get(loanId);
            loan.Id.Should().Be(loanId);
        }

        [Test]
        [Order(3)]
        public void Test_LoanIntegration_GetAll_ShouldBeOk()
        {
            var loans = _loanService.GetAll();
            loans.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_LoanIntegration_GetBookFromLoan_ShouldBeOk()
        {
            var loanId = 1;

            var book = _loanService.GetBookFromLoan(loanId);
            book.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(5)]
        public void Test_LoanIntegration_Update_ShouldBeOk()
        {
            var loan = LoanObjectMother.CreateValidLoan();
            loan.Customer = "Squanchy";

            var newLoan = _loanService.Update(loan);
            newLoan.Equals(loan).Should().BeTrue();
        }

        [Test]
        [Order(6)]
        public void Test_LoanIntegration_Delete_ShouldBeOk()
        {
            var loan = LoanObjectMother.CreateValidLoan();

            _loanService.Delete(loan);

            var loanDeleted = _loanService.Get(loan.Id);
            loanDeleted.Should().BeNull();
        }
    }
}
