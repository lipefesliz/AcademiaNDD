using Biblioteca.Domain.Base;

namespace Biblioteca.Domain.Features.Books
{
    public interface IBookRepository : IRepository<Book>
    {
        bool Exist(string title);

        Book GetByTitle(string title);

        bool IsTiedTo(long id);
    }
}
