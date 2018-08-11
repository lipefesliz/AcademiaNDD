using Biblioteca.Domain.Exceptions;
using Biblioteca.Domain.Features.Books;
using Biblioteca.Domain.Features.Books.Exceptions;
using System.Collections.Generic;

namespace Biblioteca.Applications.Features
{
    public class BookService : IService<Book>
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book Add(Book book)
        {
            book.Validate();

            bool bookFounded = _bookRepository.Exist(book.Title);
            if (bookFounded)
                throw new DuplicatedTitleException();

            return _bookRepository.Add(book);
        }

        public void Delete(Book book)
        {
            if (book.Id <= 0)
                throw new IdentifierUndefinedException();

            if (IsTiedTo(book.Id))
                throw new ItemTiedToException();

            _bookRepository.Delete(book.Id);
        }

        public Book Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            return _bookRepository.Get(id);
        }

        public IList<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book Update(Book book)
        {
            book.Validate();

            var bookFounded = _bookRepository.GetByTitle(book.Title);

            if (bookFounded != null && bookFounded.Id != book.Id)
                throw new DuplicatedTitleException();

            return _bookRepository.Update(book);
        }

        public bool IsTiedTo(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            return _bookRepository.IsTiedTo(id);
        }
    }
}
