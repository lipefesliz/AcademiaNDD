using Biblioteca.Domain.Features.Books;
using System;

namespace Biblioteca.Common.Tests.Features
{
    public static partial class BookObjectMother
    {
        public static Book CreateValidBook()
        {
            return new Book
            {
                Id = 1,
                Title = "C# - Use a Cabeca",
                Theme = "Linguagem de Programacao",
                Author = "Mad Max",
                Volume = 1,
                Publication = DateTime.Now,
                IsAvailable = true
            };
        }

        public static Book CreateInvalidBook_InvalidId()
        {
            return new Book
            {
                Id = -1
            };
        }

        public static Book CreateInvalidBook_LenghtTitle()
        {
            return new Book
            {
                Id = 1,
                Title = "C#"
            };
        }

        public static Book CreateInvalidBook_EmptyTitle()
        {
            return new Book
            {
                Id = 1,
                Title = ""
            };
        }

        public static Book CreateInvalidBook_LenghtAuthor()
        {
            return new Book
            {
                Id = 1,
                Title = "C# - Use a Cabeca",
                Author = "Max",
            };
        }

        public static Book CreateInvalidBook_EmptyAuthor()
        {
            return new Book
            {
                Id = 1,
                Title = "C# - Use a Cabeca",
                Author = "",
            };
        }

        public static Book CreateInvalidBook_LenghtTheme()
        {
            return new Book
            {
                Id = 1,
                Title = "C# - Use a Cabeca",
                Author = "Mad Max",
                Theme = "LdP",
            };
        }

        public static Book CreateInvalidBook_EmptyTheme()
        {
            return new Book
            {
                Id = 1,
                Title = "C# - Use a Cabeca",
                Author = "Mad Max",
                Theme = "",
            };
        }

        public static Book CreateInvalidBook_InvalidVolume()
        {
            return new Book
            {
                Id = 1,
                Title = "C# - Use a Cabeca",
                Theme = "Linguagem de Programacao",
                Author = "Mad Max",
                Volume = 0
            };
        }
    }
}
