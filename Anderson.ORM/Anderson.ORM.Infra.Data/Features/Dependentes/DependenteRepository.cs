using Anderson.ORM.Domain.Features.Dependentes;
using Anderson.ORM.Infra.Data.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Anderson.ORM.Infra.Data.Features.Dependentes
{
    public class DependenteRepository : IDependenteRepository
    {
        protected AndersonORMContext _contexto;

        public DependenteRepository(AndersonORMContext context)
        {
            _contexto = context;
        }

        public Dependente Add(Dependente dependente)
        {
            dependente = _contexto.Dependentes.Add(dependente);

            _contexto.SaveChanges();

            return dependente;
        }

        public void Delete(Dependente dependente)
        {
            _contexto.Dependentes.Remove(dependente);

            _contexto.SaveChanges();
        }

        public Dependente Get(long id)
        {
            return _contexto.Dependentes.Find(id);
        }

        public IEnumerable<Dependente> GetAll()
        {
            return _contexto.Dependentes;
        }

        public ICollection<Dependente> ObterPorFuncionario(string funcionario)
        {
            return _contexto.Dependentes.Where(d => d.Funcionario.Nome.Equals(funcionario)).ToList();
        }

        public Dependente Update(Dependente dependente)
        {
            _contexto.Entry(dependente).State = EntityState.Modified;

            _contexto.SaveChanges();

            return dependente;
        }
    }
}
