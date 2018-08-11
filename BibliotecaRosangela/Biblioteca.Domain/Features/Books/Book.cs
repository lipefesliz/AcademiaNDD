using Biblioteca.Domain.Base;
using Biblioteca.Domain.Features.Books.Exceptions;
using System;

namespace Biblioteca.Domain.Features.Books
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Theme { get; set; }
        public int Volume { get; set; }
        public DateTime Publication { get; set; }
        public bool IsAvailable { get; set; }

        public override void Validate()
        {
            if (String.IsNullOrEmpty(Title))
                throw new TitleIsNullOrEmptyException();

            if (Title.Length < 4)
                throw new TitleLenghtException();

            if (String.IsNullOrEmpty(Author))
                throw new AuthorIsNullOrEmptyException();

            if (Author.Length < 4)
                throw new AuthorLenghtException();

            if (String.IsNullOrEmpty(Theme))
                throw new ThemeIsNullOrEmptyException();

            if (Theme.Length < 4)
                throw new ThemeLenghtException();

            if (Volume <= 0)
                throw new NegativeVolumeException();
        }
    }
}
