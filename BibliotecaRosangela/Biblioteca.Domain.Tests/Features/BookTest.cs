using Biblioteca.Common.Tests.Features;
using Biblioteca.Domain.Features.Books.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Biblioteca.Domain.Tests.Features
{
    [TestFixture]
    public class BookTest
    {
        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_CreateBook_Validate_ShouldBeOk()
        {
            var _book = BookObjectMother.CreateValidBook();

            Action action = () => _book.Validate();
            action.Should().NotThrow<Exception>();
        }

        [Test]
        [Order(2)]
        public void Test_CreateBook_Equals_ShouldBeOkl()
        {
            var _book = BookObjectMother.CreateValidBook();

            var _emptyBook = new Object();

            var result = _book.Equals(_emptyBook);
            result.Should().BeFalse();
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(3)]
        public void Test_CreateBook_ValidateEmptyTitle_ShouldFail()
        {
            var _book = BookObjectMother.CreateInvalidBook_EmptyTitle();

            Action action = () => _book.Validate();
            action.Should().Throw<TitleIsNullOrEmptyException>();
        }

        [Test]
        [Order(4)]
        public void Test_CreateBook_ValidateLenghtTitle_ShouldFail()
        {
            var _book = BookObjectMother.CreateInvalidBook_LenghtTitle();

            Action action = () => _book.Validate();
            action.Should().Throw<TitleLenghtException>();
        }

        [Test]
        [Order(5)]
        public void Test_CreateBook_ValidateEmptyAuthor_ShouldFail()
        {
            var _book = BookObjectMother.CreateInvalidBook_EmptyAuthor();

            Action action = () => _book.Validate();
            action.Should().Throw<AuthorIsNullOrEmptyException>();
        }

        [Test]
        [Order(6)]
        public void Test_CreateBook_ValidateLenghtAuthor_ShouldFail()
        {
            var _book = BookObjectMother.CreateInvalidBook_LenghtAuthor();

            Action action = () => _book.Validate();
            action.Should().Throw<AuthorLenghtException>();
        }

        [Test]
        [Order(7)]
        public void Test_CreateBook_ValidateEmptyTheme_ShouldFail()
        {
            var _book = BookObjectMother.CreateInvalidBook_EmptyTheme();

            Action action = () => _book.Validate();
            action.Should().Throw<ThemeIsNullOrEmptyException>();
        }

        [Test]
        [Order(8)]
        public void Test_CreateBook_ValidateLenghtTheme_ShouldFail()
        {
            var _book = BookObjectMother.CreateInvalidBook_LenghtTheme();

            Action action = () => _book.Validate();
            action.Should().Throw<ThemeLenghtException>();
        }

        [Test]
        [Order(9)]
        public void Test_CreateBook_ValidateNegativeVolume_ShouldFail()
        {
            var _book = BookObjectMother.CreateInvalidBook_InvalidVolume();

            Action action = () => _book.Validate();
            action.Should().Throw<NegativeVolumeException>();
        }
    }
}
