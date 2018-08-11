using Anderson.ORM.Domain.Features.Cargos;
using Anderson.ORM.Domain.Features.Funcionarios;
using Anderson.ORM.Infra.Data.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Anderson.ORM.Infra.Data.Features.Funcionarios
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        protected AndersonORMContext _contexto;

        public FuncionarioRepository(AndersonORMContext context)
        {
            _contexto = context;
        }

        public Funcionario Add(Funcionario funcionario)
        {
            funcionario = _contexto.Funcionarios.Add(funcionario);

            _contexto.SaveChanges();

            return funcionario;
        }

        public void Delete(Funcionario funcionario)
        {
            _contexto.Funcionarios.Remove(funcionario);

            _contexto.SaveChanges();
        }

        public Funcionario Get(long id)
        {
            return _contexto.Funcionarios.Find(id);
        }

        public IEnumerable<Funcionario> GetAll()
        {
            return _contexto.Funcionarios;
        }

        public ICollection<Funcionario> ObterPorCargo(string cargo)
        {
            return _contexto.Funcionarios.Where(f => f.Cargo.Descricao.Equals(cargo)).ToList();
        }

        public Funcionario Update(Funcionario funcionario)
        {
            _contexto.Entry(funcionario).State = EntityState.Modified;

            _contexto.SaveChanges();

            return funcionario;
        }
    }
}
