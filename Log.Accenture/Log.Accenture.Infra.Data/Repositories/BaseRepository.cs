using Log.Accenture.Domain.Core;
using Log.Accenture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Log.Accenture.Infra.Data.Repositories
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        private readonly SqlServerContext _sqlServerContext;

        protected BaseRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public virtual void Create(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Added;
            _sqlServerContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Deleted;
            _sqlServerContext.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return _sqlServerContext.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(TKey id)
        {
            return _sqlServerContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }
    }
}
