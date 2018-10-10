using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using Projeto_Prova_Tdd.Applications.Features.Auditions;
using Projeto_Prova_Tdd.Commons.Tests.Feeatures.Auditions;
using Projeto_Prova_Tdd.Domain.Features.Auditions;
using Projeto_Prova_Tdd.Domain.Features.Auditions.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Prova_Tdd.Applications.Test.Features.Auditions
{
    [TestFixture]
    public class AuditionServiceTest
    {
        private AuditionService _service;
        private Mock<IAuditionRepository> _mockRepository;
        private Audition _audition;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IAuditionRepository>();
            _service = new AuditionService(_mockRepository.Object);
            _audition = AuditionObjectMother.CreateValidAudition();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_Audition_AppService_Add_ShouldBeOk()
        {
            _mockRepository
                .Setup(ar => ar.Exist(_audition.Theme))
                .Returns(false);

            _mockRepository
                .Setup(ar => ar.Add(_audition))
                .Returns(_audition);

            var auditionAdded = _service.Add(_audition);

            _mockRepository.Verify(ar => ar.Add(_audition));
            auditionAdded.Id.Should().Be(_audition.Id);
        }

        [Test]
        [Order(2)]
        public void Test_Audition_AppService_Update_ShouldBeOk()
        {
            _mockRepository
                .Setup(ar => ar.GetByAudition(_audition.Theme))
                .Returns(_audition);

            _mockRepository
                .Setup(ar => ar.Update(_audition))
                .Returns(_audition);

            var auditionUpdated = _service.Update(_audition);

            _mockRepository.Verify(ar => ar.Update(_audition));
            auditionUpdated.Id.Should().Be(_audition.Id);
        }

        [Test]
        [Order(3)]
        public void Test_Audition_AppService_Delete_ShouldBeOk()
        {
            _mockRepository
                .Setup(ar => ar.Delete(_audition.Id));

            _service.Delete(_audition);

            _mockRepository
                .Setup(ar => ar.Get(_audition.Id));

            var auditionDeleted = _service.Get(_audition.Id);

            _mockRepository.Verify(ar => ar.Delete(_audition.Id));
            auditionDeleted.Should().BeNull();
        }

        [Test]
        [Order(4)]
        public void Test_Audition_AppService_Get_ShouldBeOk()
        {
            _mockRepository
                .Setup(ar => ar.Get(_audition.Id))
                .Returns(_audition);

            var audition = _service.Get(_audition.Id);

            _mockRepository.Verify(ar => ar.Get(_audition.Id));
            audition.Id.Should().Be(_audition.Id);
        }

        [Test]
        [Order(5)]
        public void Test_Audition_AppService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(ar => ar.GetAll())
                .Returns(new List<Audition> { _audition });

            IList<Audition> auditions = _service.GetAll();

            _mockRepository.Verify(ar => ar.GetAll());
            auditions.First().Id.Should().Be(_audition.Id);
        }

        /* TESTES ALTERENATIVOS */
        [Test]
        [Order(6)]
        public void Test_Audition_AppService_Add_Throw_DuplicatedThemeException()
        {
            _mockRepository
                .Setup(ar => ar.Exist(_audition.Theme))
                .Returns(true);

            _mockRepository
                .Setup(ar => ar.Add(_audition))
                .Throws<DuplicatedThemeException>();

            Action action = () => _service.Add(_audition);

            action.Should().Throw<DuplicatedThemeException>();
        }
    }
}
