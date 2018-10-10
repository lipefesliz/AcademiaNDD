using FluentAssertions;
using NUnit.Framework;
using Projeto_Prova_Tdd.Commons.Tests.Feeatures.Results;
using Projeto_Prova_Tdd.Domain.Features.Results;
using Projeto_Prova_Tdd.Domain.Features.Results.Exceptions;
using System;

namespace Projeto_Prova_Tdd.Domain.Test.Features.Results
{
    [TestFixture]
    public class ResultsDomainTests
    {
        private Result _result;

        [SetUp]
        public void Initialize()
        {
            _result = ResultObjectMother.CreateValidResult();
        }

        /* TESTES NORMAIS */
        [Test]
        [Order(1)]
        public void Test_Result_Domain_Create_Result_ShouldBeOk()
        {
            Action action = _result.Validate;

            action.Should().NotThrow<Exception>();
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        [Order(2)]
        public void Test_Result_Domain_Create_InvalidResult_WithoutStudent()
        {
            _result.Student = null;

            Action action = _result.Validate;

            action.Should().Throw<NoStudentException>();
        }

        [Test]
        [Order(3)]
        public void Test_Result_Domain_Create_InvalidResult_WithoutGrade()
        {
            _result.Grade = -1;

            Action action = _result.Validate;

            action.Should().Throw<InvalidGradeException>();
        }
    }
}
