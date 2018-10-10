using NUnit.Framework;
using Projeto_Prova_Tdd.Domain.Features.Students;
using Projeto_Prova_Tdd.Infra.Data.Features.Students;
using Projeto_Prova_Tdd.Commons.Tests.Base;
using Projeto_Prova_Tdd.Commons.Tests.Feeatures.Students;
using FluentAssertions;
using System.Linq;

namespace Projeto_Prova_Tdd.Infra.Data.Tests.Features.Students
{
    [TestFixture]
    public class StudentIntegrationDataTest
    {
        private IStudentRepository _repository;
        private Student _student;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new StudentRepository();
            _student = StudentObjectMother.CreateValidStudent();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_Student_IntegrationData_Add_ShouldBeOk()
        {
            var newStudent = _repository.Add(_student);

            newStudent.Id.Should().Be(_student.Id);
        }

        [Test]
        [Order(2)]
        public void Test_Student_IntegrationData_Get_ShouldBeOk()
        {
            var student = _repository.Get(_student.Id);

            student.Id.Should().Be(_student.Id);
        }

        [Test]
        [Order(3)]
        public void Test_Student_IntegrationData_GetAll_ShouldBeOk()
        {
            var students = _repository.GetAll();

            students.First().Id.Should().Be(_student.Id);
        }

        [Test]
        [Order(4)]
        public void Test_Student_IntegrationData_GetByName_ShouldBeOk()
        {
            _student.Name = "Felipe";

            var student = _repository.GetByName(_student.Name);

            student.Name.Should().Be(_student.Name);
        }

        [Test]
        [Order(5)]
        public void Test_Student_IntegrationData_Update_ShouldBeOk()
        {
            _student.Name = "Diego";

            var newStudent = _repository.Update(_student);

            newStudent.Equals(_student).Should().BeTrue();
        }

        [Test]
        [Order(6)]
        public void Test_Student_IntegrationData_Delete_ShouldBeOk()
        {
            _student = _repository.Add(_student);

            _repository.Delete(_student.Id);

            var studentDeleted = _repository.Get(_student.Id);

            studentDeleted.Should().BeNull();
        }

        [Test]
        [Order(7)]
        public void Test_Student_IntegrationData_Exist_ShouldBeOk()
        {
            bool result = _repository.Exist("Felipe");

            result.Should().Be(true);
        }

        [Test]
        [Order(8)]
        public void Test_Student_IntegrationData_IsTiedTo_ShouldBeOk()
        {
            bool result = _repository.IsTiedTo(_student.Id);

            result.Should().Be(true);
        }
    }
}
