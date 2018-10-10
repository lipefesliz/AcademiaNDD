using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_Prova_Tdd.Applications.Features.Students;
using Projeto_Prova_Tdd.Commons.Tests.Feeatures.Students;
using Projeto_Prova_Tdd.Domain.Features.Students;
using System.Collections.Generic;
using Projeto_Prova_Tdd.Domain.Exceptions;
using System;

namespace Projeto_Prova_Tdd.Applications.Test.Features.Students
{
    [TestFixture]
    public class StudentServiceTests
    {
        private StudentService _service;
        private Mock<IStudentRepository> _mockRepository;
        private Student _student;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IStudentRepository>();
            _service = new StudentService(_mockRepository.Object);
            _student = StudentObjectMother.CreateValidStudent();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_Student_AppService_Add_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.Exist(_student.Name))
                .Returns(false);

            _mockRepository
                .Setup(sr => sr.Add(_student))
                .Returns(new Student { Id = 1 });

            var studentAdded = _service.Add(_student);

            _mockRepository.Verify(sr => sr.Add(_student));
            studentAdded.Id.Should().Be(_student.Id);
        }

        [Test]
        [Order(2)]
        public void Test_Student_AppService_Update_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.GetByName(_student.Name))
                .Returns(new Student { Id = 1 });

            _mockRepository
                .Setup(sr => sr.Update(_student))
                .Returns(new Student { Id = 1 });

            var studentUpdated = _service.Update(_student);

            _mockRepository.Verify(sr => sr.Update(_student));
            studentUpdated.Id.Should().Be(_student.Id);
        }

        [Test]
        [Order(3)]
        public void Test_Student_AppService_Delete_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.Delete(_student.Id));

            _service.Delete(_student);

            _mockRepository
                .Setup(er => er.Get(_student.Id));

            var studentDeleted = _service.Get(_student.Id);

            _mockRepository.Verify(sr => sr.Delete(_student.Id));
            studentDeleted.Should().BeNull();
        }

        [Test]
        [Order(4)]
        public void Test_Student_AppService_Get_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.Get(_student.Id))
                .Returns(new Student { Id = 1 });

            var student = _service.Get(_student.Id);

            _mockRepository.Verify(sr => sr.Get(_student.Id));
            student.Id.Should().Be(_student.Id);
        }

        [Test]
        [Order(5)]
        public void Test_Student_AppService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.GetAll())
                .Returns(new List<Student> { new Student { Id = 1 }, new Student { Id = 2 } });

            IList<Student> students = _service.GetAll();

            _mockRepository.Verify(sr => sr.GetAll());
            students.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(6)]
        public void Test_Student_AppService_IsTiedTo_ShouldBeOk()
        {
            var Id = 1;

            _mockRepository
                .Setup(sr => sr.IsTiedTo(Id))
                .Returns(false);

            bool result = _service.IsTiedTo(Id);
            result.Should().Be(false);
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        [Order(7)]
        public void Test_Student_AppService_Add_Throw_DuplicatedNameException()
        {
            _mockRepository
                .Setup(sr => sr.Exist(_student.Name))
                .Returns(true);

            _mockRepository
                .Setup(sr => sr.Add(_student))
                .Throws<DuplicatedNameException>();

            Action action = () => _service.Add(_student);

            action.Should().Throw<DuplicatedNameException>();
        }
    }
}
