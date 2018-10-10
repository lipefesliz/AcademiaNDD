using NUnit.Framework;
using Projeto_Prova_Tdd.Domain.Features.Results;
using Projeto_Prova_Tdd.Infra.Data.Features.Results;
using Projeto_Prova_Tdd.Commons.Tests.Base;
using Projeto_Prova_Tdd.Commons.Tests.Feeatures.Results;
using FluentAssertions;
using System.Linq;

namespace Projeto_Prova_Tdd.Infra.Data.Tests.Features.Results
{
    [TestFixture]
    public class ResultIntegrationDataTest
    {
        private IResultRepository _repository;
        private Result _result;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new ResultRepository();
            _result = ResultObjectMother.CreateValidResult();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_Result_IntegrationData_Add_ShouldBeOk()
        {
            var newResult = _repository.Add(_result);

            newResult.Id.Should().Be(_result.Id);
        }

        [Test]
        [Order(2)]
        public void Test_Result_IntegrationData_Get_ShouldBeOk()
        {
            var result = _repository.Get(_result.Id);

            result.Id.Should().Be(_result.Id);
        }

        [Test]
        [Order(3)]
        public void Test_Result_IntegrationData_GetAll_ShouldBeOk()
        {
            var results = _repository.GetAll();

            results.First().Id.Should().Be(_result.Id);
        }

        [Test]
        [Order(4)]
        public void Test_Result_IntegrationData_GetByStudent_ShouldBeOk()
        {
            var result = _repository.GetByStudent(_result.Student.Id);

            result.Id.Should().Be(_result.Id);
        }

        [Test]
        [Order(5)]
        public void Test_Result_IntegrationData_Update_ShouldBeOk()
        {
            _result.Grade = 9;

            var newResult = _repository.Update(_result);

            newResult.Equals(_result).Should().BeTrue();
        }

        [Test]
        [Order(6)]
        public void Test_Result_IntegrationData_Delete_ShouldBeOk()
        {
            _result = _repository.Add(_result);

            _repository.Delete(_result.Id);

            var resultDeleted = _repository.Get(_result.Id);

            resultDeleted.Should().BeNull();
        }

        [Test]
        [Order(7)]
        public void Test_Result_IntegrationData_Exist_ShouldBeOk()
        {
            bool result = _repository.Exist(_result.Student.Id);

            result.Should().Be(true);
        }

        [Test]
        [Order(8)]
        public void Test_Result_IntegrationData_IsTiedTo_ShouldBeOk()
        {
            bool result = _repository.IsTiedTo(_result.Id);

            result.Should().Be(true);
        }
    }
}
