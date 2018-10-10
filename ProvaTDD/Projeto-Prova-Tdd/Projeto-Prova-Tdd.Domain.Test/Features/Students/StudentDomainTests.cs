using FluentAssertions;
using NUnit.Framework;
using Projeto_Prova_Tdd.Commons.Tests.Feeatures.Students;
using Projeto_Prova_Tdd.Domain.Features.Students;
using Projeto_Prova_Tdd.Domain.Features.Students.Exceptions;
using System;

namespace Projeto_Prova_Tdd.Domain.Test.Features.Students
{
    [TestFixture]
    public class StudentDomainTests
    {
        private Student _student;

        [SetUp]
        public void Initialize()
        {
            _student = StudentObjectMother.CreateValidStudent();
        }

        /* TESTES NORMAIS */
        [Test]
        [Order(1)]
        public void Test_Student_Domain_Create_Student_ShouldBeOk()
        {
            Action action = _student.Validate;

            action.Should().NotThrow<Exception>();
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        [Order(2)]
        public void Test_Student_Domain_Create_InvalidStudent_NoName()
        {
            _student.Name = String.Empty;

            Action action = _student.Validate;

            action.Should().Throw<NoNameException>();
        }
    }
}
