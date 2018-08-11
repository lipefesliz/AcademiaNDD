using Anderson.ORM.Domain.Features.Projetos;
using Anderson.ORM.Infra.Data.Base;
using System.Collections.Generic;
using System.Data.Entity;

namespace Anderson.ORM.Infra.Data.Features.Projetos
{
    public class ProjetoRepository : IProjetoRepository
    {
        protected AndersonORMContext _contexto;

        public ProjetoRepository(AndersonORMContext context)
        {
            _contexto = context;
        }

        public Projeto Add(Projeto projeto)
        {
            projeto = _contexto.Projetos.Add(projeto);

            _contexto.SaveChanges();

            return projeto;
        }

        public void Delete(Projeto projeto)
        {
            _contexto.Projetos.Remove(projeto);

            _contexto.SaveChanges();
        }

        public Projeto Get(long id)
        {
            return _contexto.Projetos.Find(id);
        }

        public IEnumerable<Projeto> GetAll()
        {
            return _contexto.Projetos;
        }

        public Projeto Update(Projeto projeto)
        {
            _contexto.Entry(projeto).State = EntityState.Modified;

            _contexto.SaveChanges();

            return projeto;
        }
    }
}
