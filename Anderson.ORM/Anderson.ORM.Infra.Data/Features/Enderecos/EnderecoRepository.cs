using Anderson.ORM.Domain.Features.Enderecos;
using Anderson.ORM.Infra.Data.Base;
using System.Collections.Generic;
using System.Data.Entity;

namespace Anderson.ORM.Infra.Data.Features.Enderecos
{
    public class EnderecoRepository : IEnderecoRepository
    {
        protected AndersonORMContext _contexto;

        public EnderecoRepository(AndersonORMContext context)
        {
            _contexto = context;
        }

        public Endereco Add(Endereco endereco)
        {
            endereco = _contexto.Enderecos.Add(endereco);

            _contexto.SaveChanges();

            return endereco;
        }

        public void Delete(Endereco endereco)
        {
            _contexto.Enderecos.Remove(endereco);

            _contexto.SaveChanges();
        }

        public Endereco Get(long id)
        {
            return _contexto.Enderecos.Find(id);
        }

        public IEnumerable<Endereco> GetAll()
        {
            return _contexto.Enderecos;
        }

        public Endereco Update(Endereco endereco)
        {
            _contexto.Entry(endereco).State = EntityState.Modified;

            _contexto.SaveChanges();

            return endereco;
        }
    }
}
