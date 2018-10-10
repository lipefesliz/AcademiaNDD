using FluentAssertions;
using NUnit.Framework;
using Projeto_Prova_Tdd.Domain.Features.Auditions;
using Projeto_Prova_Tdd.Domain.Features.Results;
using System;
using System.Collections.Generic;
using Projeto_Prova_Tdd.Domain.Features.Auditions.Exceptions;
using Projeto_Prova_Tdd.Commons.Tests.Feeatures.Auditions;

namespace Projeto_Prova_Tdd.Domain.Test.Features.Auditions
{
    [TestFixture]
    public class AuditionDomainTests
    {
        private Audition _audition;

        [SetUp]
        public void Initialize()
        {
            _audition = AuditionObjectMother.CreateValidAudition();
        }

        /* TESTES NORMAIS */
        [Test]
        [Order(1)]
        public void Test_Audition_Domain_Create_Audition_ShouldBeOk()
        {
            Action action = _audition.Validate;

            action.Should().NotThrow<Exception>();
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        [Order(2)]
        public void Test_Audition_Domain_Create_InvalidAudition_WithoutResults()
        {
            _audition.Results = new List<Result>();

            Action action = _audition.Validate;

            action.Should().Throw<NoResultsException>();
        }
    }
}
