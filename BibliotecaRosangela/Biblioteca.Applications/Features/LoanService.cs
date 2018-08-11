using Biblioteca.Domain.Exceptions;
using Biblioteca.Domain.Features.Books;
using Biblioteca.Domain.Features.Loans;
using System.Collections.Generic;

namespace Biblioteca.Applications.Features
{
    public class LoanService : IService<Loan>
    {
        private ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public Loan Add(Loan loan)
        {
            loan.Validate();

            return _loanRepository.Add(loan);
        }

        public void Delete(Loan loan)
        {
            if (loan.Id <= 0)
                throw new IdentifierUndefinedException();

            _loanRepository.Delete(loan.Id);
        }

        public Loan Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            return _loanRepository.Get(id);
        }

        public IList<Loan> GetAll()
        {
            return _loanRepository.GetAll();
        }

        public Book GetBookFromLoan(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            return _loanRepository.GetBookFromLoan(id);
        }

        public Loan Update(Loan loan)
        {
            if (loan.Id <= 0)
                throw new IdentifierUndefinedException();

            loan.Validate();

            return _loanRepository.Update(loan);
        }
    }
}
