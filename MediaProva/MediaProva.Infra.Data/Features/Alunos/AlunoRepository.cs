using System.Collections.Generic;
using System.Data.Entity;
using MediaProva.Domain.Features.Alunos;
using MediaProva.Infra.Data.Base;

namespace MediaProva.Infra.Data.Features.Alunos
{
    public class AlunoRepository : IAlunoRepository
    {
        protected MediaProvaContext _contexto;

        public AlunoRepository(MediaProvaContext contexto)
        {
            _contexto = contexto;
        }

        public Aluno Add(Aluno aluno)
        {
            aluno = _contexto.Alunos.Add(aluno);

            _contexto.SaveChanges();

            return aluno;
        }

        public void Delete(Aluno aluno)
        {
            _contexto.Alunos.Remove(aluno);

            _contexto.SaveChanges();
        }

        public Aluno Get(long id)
        {
            return _contexto.Alunos.Find(id);
        }

        public IEnumerable<Aluno> GetAll()
        {
            return _contexto.Alunos;
        }

        public Aluno Update(Aluno aluno)
        {
            _contexto.Entry(aluno).State = EntityState.Modified;

            _contexto.SaveChanges();

            return aluno;
        }
    }
}
