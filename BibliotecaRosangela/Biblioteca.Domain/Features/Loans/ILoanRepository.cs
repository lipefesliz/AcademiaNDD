using Biblioteca.Domain.Base;
using Biblioteca.Domain.Features.Books;

namespace Biblioteca.Domain.Features.Loans
{
    public interface ILoanRepository : IRepository<Loan>
    {
        Loan GetByBook(int id);

        Book GetBookFromLoan(long id);
    }
}
