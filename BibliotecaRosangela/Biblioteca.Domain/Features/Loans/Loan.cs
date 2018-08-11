using Biblioteca.Domain.Base;
using Biblioteca.Domain.Features.Books;
using Biblioteca.Domain.Features.Loans.Exceptions;
using System;

namespace Biblioteca.Domain.Features.Loans
{
    public class Loan : Entity
    {
        public string Customer { get; set; }
        public Book Book { get; set; }
        public DateTime ReturnDate { get; set; }

        public override void Validate()
        {
            if (String.IsNullOrEmpty(Customer))
                throw new CustomerIsNullOrEmptyException();

            if (Customer.Length < 4)
                throw new CustomerLengthException();

            if (ReturnDate < Book.Publication)
                throw new ReturnDateException();
        }

        public double CalculateTax()
        {
            var tax = 2.5;
            var devolution = DateTime.Now;

            if (ReturnDate < devolution)
                return (devolution.Day - ReturnDate.Day) * tax;

            return 0;
        }
    }
}
