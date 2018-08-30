using MF6.Domain.Base;
using MF6.Domain.Exceptions;
using MF6.Infra.ORM.Contexts;
using System.Data.Entity;
using System.Linq;

namespace MF6.Infra.ORM.Base
{
    public class AbstractRepository<T> : IRepository<T> where T : Entity
    {
        private MF6Context _context;

        public AbstractRepository(MF6Context context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            var newEntity = _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return newEntity;
        }

        public IQueryable<T> GetAll()
        {
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
