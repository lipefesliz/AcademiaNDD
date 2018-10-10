using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using Projeto_Prova_Tdd.Applications.Features.Results;
using Projeto_Prova_Tdd.Commons.Tests.Feeatures.Results;
using Projeto_Prova_Tdd.Domain.Features.Results;
using Projeto_Prova_Tdd.Domain.Features.Students;
using System.Collections.Generic;
using System.Linq;
using Projeto_Prova_Tdd.Domain.Features.Results.Exceptions;

namespace Projeto_Prova_Tdd.Applications.Test.Features.Results
{
    [TestFixture]
    public class ResultServiceTest
    {
        private ResultService _service;
        private Mock<IResultRepository> _mockRepository;
        private Result _result;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IResultRepository>();
            _service = new ResultService(_mockRepository.Object);
            _result = ResultObjectMother.CreateValidResult();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_Result_AppService_Add_ShouldBeOk()
        {
            _mockRepository
                .Setup(rr => rr.Exist(_result.Student.Id))
                .Returns(false);

            _mockRepository
                .Setup(rr => rr.Add(_result))
                .Returns(_result);

            var resultAdded = _service.Add(_result);

            _mockRepository.Verify(rr => rr.Add(_result));
            resultAdded.Id.Should().Be(_result.Id);
        }

        [Test]
        [Order(2)]
        public void Test_Result_AppService_Update_ShouldBeOk()
        {
            _mockRepository
                .Setup(rr => rr.GetByStudent(_result.Student.Id))
                .Returns(new Result(new Student { }) { });

            _mockRepository
                .Setup(rr => rr.Update(_result))
                .Returns(_result);

            var resultUpdated = _service.Update(_result);

            _mockRepository.Verify(rr => rr.Update(_result));
            resultUpdated.Id.Should().Be(_result.Id);
        }

        [Test]
        [Order(3)]
        public void Test_Result_AppService_Delete_ShouldBeOk()
        {
            _mockRepository
                .Setup(rr => rr.Delete(_result.Id));

            _service.Delete(_result);

            _mockRepository
                .Setup(rr => rr.Get(_result.Id));

            var resultDeleted = _service.Get(_result.Id);

            _mockRepository.Verify(rr => rr.Delete(_result.Id));
            resultDeleted.Should().BeNull();
        }

        [Test]
        [Order(4)]
        public void Test_Result_AppService_Get_ShouldBeOk()
        {
            _mockRepository
                .Setup(rr => rr.Get(_result.Id))
                .Returns(_result);

            var result = _service.Get(_result.Id);

            _mockRepository.Verify(rr => rr.Get(_result.Id));
            result.Id.Should().Be(_result.Id);
        }

        [Test]
        [Order(5)]
        public void Test_Result_AppService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(rr => rr.GetAll())
                .Returns(new List<Result> { _result });

            IList<Result> results = _service.GetAll();

            _mockRepository.Verify(rr => rr.GetAll());
            results.First().Id.Should().Be(_result.Id);
        }

        [Test]
        [Order(6)]
        public void Test_Result_AppService_IsTiedTo_ShouldBeOk()
        {
            var Id = 1;

            _mockRepository
                .Setup(rr => rr.IsTiedTo(Id))
                .Returns(false);

            bool result = _service.IsTiedTo(Id);
            result.Should().Be(false);
        }

        /* TESTES ALTERENATIVOS */
        [Test]
        [Order(7)]
        public void Test_Result_AppService_Add_Throw_DuplicatedGradeException()
        {
            _mockRepository
                .Setup(rr => rr.Exist(_result.Student.Id))
                .Returns(true);

            _mockRepository
                .Setup(rr => rr.Add(_result))
                .Throws<DuplicatedGradeException>();

            Action action = () => _service.Add(_result);

            action.Should().Throw<DuplicatedGradeException>();
        }
    }
}
