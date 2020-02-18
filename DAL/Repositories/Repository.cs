using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }
       
        public virtual void Update(TEntity entity)
        {
            var a = _entities.Update(entity);
            _context.SaveChanges();
        }
        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
