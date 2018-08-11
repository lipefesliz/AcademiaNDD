using Biblioteca.Domain.Features.Books;
using Biblioteca.Domain.Features.Loans;
using System;

namespace Biblioteca.Common.Tests.Features
{
    public static partial class LoanObjectMother
    {
        public static Loan CreateValidLoan()
        {
            return new Loan
            {
                Id = 1,
                Customer = "Rick Sanchez",
                Book = new Book
                {
                    Id = 1
                },
                ReturnDate = DateTime.Now,
            };
        }

        public static Loan CreateInvalidLoan_InvalidId()
        {
            return new Loan
            {
                Id = -1,
            };
        }

        public static Loan CreateInvalidLoan_EmptyCustomer()
        {
            return new Loan
            {
                Id = 1,
                Customer = ""
            };
        }

        public static Loan CreateInvalidLoan_LengthCustomer()
        {
            return new Loan
            {
                Id = 1,
                Customer = "Ed"
            };
        }

        public static Loan CreateInvalidLoan_InvalidReturnDate()
        {
            return new Loan
            {
                Id = 1,
                Customer = "Rick Sanchez",
                Book = new Book
                {
                    Id = 1,
                    Publication = DateTime.Now
                },
                ReturnDate = DateTime.Now.AddDays(-1)
            };
        }
    }
}
