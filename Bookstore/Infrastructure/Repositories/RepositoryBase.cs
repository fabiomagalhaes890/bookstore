using Bookstore.Help.Exceptions;
using Bookstore.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bookstore.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        private readonly DbContext _context;
        private readonly string _entityName;
        protected DbSet<TEntity> Set { get; set; }
        public RepositoryBase(
            DbContext context)
        {
            _context = context;
            Set = context.Set<TEntity>();
            _entityName = typeof(TEntity).GetTypeInfo().Name;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            try
            {
                await Set.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new CreateException("An error was encountered while creating the " + _entityName, ex);
            }
        }

        public async void Update(TEntity entity)
        {
            try
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    Set.Attach(entity);
                    _context.Entry(entity).State = EntityState.Modified;
                }

                Set.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new UpdateException("An error was encountered while updating the " + _entityName, ex);
            }
        }

        public async Task<TEntity?> Get(Guid id)
        {
            try
            {
                var result = await Set.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new ReadException("An error was encountered while searching the " + _entityName, ex);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                return await Set.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ReadException("An error was encountered while loading the " + _entityName, ex);
            }
        }

        public async void RemoveAsync(TEntity entity)
        {
            try
            {
                Set.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DeleteException("An error was encountered while removing the " + _entityName, ex);
            }
        }
    }
}
