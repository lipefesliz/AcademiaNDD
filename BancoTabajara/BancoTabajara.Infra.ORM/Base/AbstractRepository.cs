using System.Data.Entity;
using System.Linq;
using BancoTabajara.Domain.Base;
using BancoTabajara.Domain.Exceptions;
using BancoTabajara.Infra.ORM.Contexts;

namespace BancoTabajara.Infra.ORM.Base
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : Entity
    {
        protected BancoTabajaraDbContext _context;

        public AbstractRepository(BancoTabajaraDbContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            var newEntity = _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return newEntity;
        }

        public IQueryable<T> GetAll(int? quantidade = null)
        {
            if (quantidade != null)
                return _context.Set<T>().Take((int)quantidade);

            return _context.Set<T>();
        }

        public T GetbyId(long entityId)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == entityId);
        }

        public bool Remove(long entityId)
        {
            var entity = _context.Set<T>().Where(e => e.Id == entityId).FirstOrDefault();

            if (entity == null)
                throw new NotFoundException();

            _context.Entry(entity).State = EntityState.Deleted;

            return _context.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return _context.SaveChanges() > 0;
        }
    }
}
