using System.Collections.Generic;
using System.Data.Entity;
using Anderson.ORM.Domain.Features.Cargos;
using Anderson.ORM.Infra.Data.Base;

namespace Anderson.ORM.Infra.Data.Features.Cargos
{
    public class CargoRepository : ICargoRepository
    {
        protected AndersonORMContext _contexto;

        public CargoRepository(AndersonORMContext context)
        {
            _contexto = context;
        }

        public Cargo Add(Cargo cargo)
        {
            cargo = _contexto.Cargos.Add(cargo);

            _contexto.SaveChanges();

            return cargo;
        }

        public void Delete(Cargo cargo)
        {
            _contexto.Cargos.Remove(cargo);

            _contexto.SaveChanges();
        }

        public Cargo Get(long id)
        {
            return _contexto.Cargos.Find(id);
        }

        public IEnumerable<Cargo> GetAll()
        {
            return _contexto.Cargos;
        }

        public Cargo Update(Cargo cargo)
        {
            _contexto.Entry(cargo).State = EntityState.Modified;

            _contexto.SaveChanges();

            return cargo;
        }
    }
}
