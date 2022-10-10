using Bookstore.Infrastructure.Base;

namespace Bookstore.Infrastructure.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<TEntity?> Get(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        void Update(TEntity entity);
        void RemoveAsync(TEntity entity);
    }
}
