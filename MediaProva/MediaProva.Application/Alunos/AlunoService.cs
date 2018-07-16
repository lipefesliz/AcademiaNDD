using System.Collections.Generic;
using MediaProva.Domain.Exceptions;
using MediaProva.Domain.Features.Alunos;

namespace MediaProva.Application.Alunos
{
    public class AlunoService : IAlunoService
    {
        private IAlunoRepository _repositorio;

        public AlunoService(IAlunoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public Aluno Add(Aluno aluno)
        {
            aluno.Validate();

            return _repositorio.Add(aluno);
        }

        public void Delete(Aluno aluno)
        {
            if (aluno.Id < 1)
                throw new IdentifierUndefinedException();

            _repositorio.Delete(aluno);
        }

        public Aluno Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _repositorio.Get(id);
        }

        public IEnumerable<Aluno> GetAll()
        {
            return _repositorio.GetAll();
        }

        public Aluno Update(Aluno aluno)
        {
            if (aluno.Id < 1)
                throw new IdentifierUndefinedException();

            aluno.Validate();

            return _repositorio.Update(aluno);
        }
    }
}
