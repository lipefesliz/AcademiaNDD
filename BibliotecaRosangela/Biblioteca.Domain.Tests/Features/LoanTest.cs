using Biblioteca.Common.Tests.Features;
using Biblioteca.Domain.Exceptions;
using Biblioteca.Domain.Features.Loans.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Biblioteca.Domain.Tests.Features
{
    [TestFixture]
    public class LoanTest
    {
        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_CreateLoan_Validate_ShouldBeOk()
        {
            var _loan = LoanObjectMother.CreateValidLoan();

            Action action = () => _loan.Validate();
            action.Should().NotThrow<Exception>();
        }

        [Test]
        [Order(2)]
        public void Test_CreateLoan_CalculateTaxInTimeReturn_ShouldBeOk()
        {
            var _loan = LoanObjectMother.CreateValidLoan();
            _loan.ReturnDate = DateTime.Now.AddDays(2);

            var result = _loan.CalculateTax();
            result.Should().Be(0);
        }

        [Test]
        [Order(3)]
        public void Test_CreateLoan_CalculateTaxLateReturn_ShouldBeOk()
        {
            var _loan = LoanObjectMother.CreateValidLoan();
            _loan.ReturnDate = DateTime.Now.AddDays(-2);

            var result = _loan.CalculateTax();
            result.Should().Be(5);
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(4)]
        public void Test_CreateLoan_ValidateEmptyCustomer_ShouldFail()
        {
            var _loan = LoanObjectMother.CreateInvalidLoan_EmptyCustomer();

            Action action = () => _loan.Validate();
            action.Should().Throw<CustomerIsNullOrEmptyException>();
        }

        [Test]
        [Order(5)]
        public void Test_CreateLoan_ValidateLengthCustomer_ShouldFail()
        {
            var _loan = LoanObjectMother.CreateInvalidLoan_LengthCustomer();

            Action action = () => _loan.Validate();
            action.Should().Throw<CustomerLengthException>();
        }

        [Test]
        [Order(6)]
        public void Test_CreateLoan_ValidateReturnDate_ShouldFail()
        {
            var _loan = LoanObjectMother.CreateInvalidLoan_InvalidReturnDate();

            Action action = () => _loan.Validate();
            action.Should().Throw<ReturnDateException>();
        }
    }
}
