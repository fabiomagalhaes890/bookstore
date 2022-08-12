using Bookstore.Infrastructure.Base;
using Bookstore.Infrastructure.Models;

namespace Bookstore.Application
{
    public interface IApplicationServiceBase<TModel, TEntity> where TModel : Model where TEntity : Entity
    {
        Task<TModel?> Get(Guid id);
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> Add(TModel entity);
        Task<TModel> Update(Guid id, TModel entity);
        void RemoveAsync(TModel entity);
    }
}
