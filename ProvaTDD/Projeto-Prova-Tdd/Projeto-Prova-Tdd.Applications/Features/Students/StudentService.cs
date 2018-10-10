using System.Collections.Generic;
using Projeto_Prova_Tdd.Domain.Features.Students;
using Projeto_Prova_Tdd.Domain.Exceptions;

namespace Projeto_Prova_Tdd.Applications.Features.Students
{
    public class StudentService : IService<Student>
    {
        private IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student Add(Student student)
        {
            student.Validate();

            var studentFounded = _studentRepository.Exist(student.Name);
            if (studentFounded)
                throw new DuplicatedNameException();

            return _studentRepository.Add(student);
        }

        public void Delete(Student student)
        {
            if (student.Id < 1)
                throw new IdentifierUndefinedException();

            if (IsTiedTo(student.Id))
                throw new IsTiedException();

            _studentRepository.Delete(student.Id);
        }

        public Student Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _studentRepository.Get(id);
        }

        public IList<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student Update(Student student)
        {
            if (student.Id < 1)
                throw new IdentifierUndefinedException();

            student.Validate();

            var studentFounded = _studentRepository.GetByName(student.Name);
            if (studentFounded != null)
            {
                if (studentFounded.Id != student.Id)
                    throw new DuplicatedNameException();
            }

            return _studentRepository.Update(student);
        }

        public bool IsTiedTo(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _studentRepository.IsTiedTo(id);
        }
    }
}
