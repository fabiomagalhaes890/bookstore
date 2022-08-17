using Bookstore.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        private readonly DbContext _context;
        protected DbSet<TEntity> Set { get; set; }
        public RepositoryBase(
            DbContext context)
        {
            _context = context;
            Set = context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            if (Set == null)
                throw new Exception();

            if (entity == null)
                throw new Exception("There isn't data to be registered.");

            await Set.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            if (Set == null)
                throw new Exception();

            if (entity == null)
                throw new Exception("There isn't data to be registered.");

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                Set.Attach(entity);
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }

            Set.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity?> Get(Guid id)
        {
            if (Set == null)
                throw new Exception();

            var result = await Set.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            if (Set == null)
                throw new Exception();

            return await Set.ToListAsync();
        }

        public async void RemoveAsync(TEntity entity)
        {
            if (Set == null)
                throw new Exception();

            Set.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
