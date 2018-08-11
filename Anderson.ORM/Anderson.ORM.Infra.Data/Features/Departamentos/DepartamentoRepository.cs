using System.Collections.Generic;
using System.Data.Entity;
using Anderson.ORM.Domain.Features.Departamentos;
using Anderson.ORM.Infra.Data.Base;

namespace Anderson.ORM.Infra.Data.Features.Departamentos
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        protected AndersonORMContext _contexto;

        public DepartamentoRepository(AndersonORMContext context)
        {
            _contexto = context;
        }

        public Departamento Add(Departamento departamento)
        {
            departamento = _contexto.Departamentos.Add(departamento);

            _contexto.SaveChanges();

            return departamento;
        }

        public void Delete(Departamento departamento)
        {
            _contexto.Departamentos.Remove(departamento);

            _contexto.SaveChanges();
        }

        public Departamento Get(long id)
        {
            return _contexto.Departamentos.Find(id);
        }

        public IEnumerable<Departamento> GetAll()
        {
            return _contexto.Departamentos;
        }

        public Departamento Update(Departamento departamento)
        {
            _contexto.Entry(departamento).State = EntityState.Modified;

            _contexto.SaveChanges();

            return departamento;
        }
    }
}
