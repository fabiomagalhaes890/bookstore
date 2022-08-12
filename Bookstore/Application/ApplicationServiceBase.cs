using AutoMapper;
using Bookstore.Help.Configs;
using Bookstore.Infrastructure.Base;
using Bookstore.Infrastructure.Models;
using Bookstore.Infrastructure.Repositories;

namespace Bookstore.Application
{
    public class ApplicationServiceBase<TModel, TEntity> : IApplicationServiceBase<TModel, TEntity> where TModel : Model where TEntity : Entity
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;
        private readonly IMapper _mapper;
        public ApplicationServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
            var configMap = ConfigurationMap.RegisterMappings();
            _mapper = configMap.CreateMapper();
        }

        public async Task<TModel> Add(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            var result = await _repositoryBase.Add(entity);

            return _mapper.Map<TModel>(result);
        }

        public async Task<TModel?> Get(Guid id)
        {
            var model = await _repositoryBase.Get(id);
            return _mapper.Map<TModel>(model);
        }

        public async Task<IEnumerable<TModel>> GetAll()
        {
            var entities = await _repositoryBase.GetAll();

            if (entities == null)
                return Enumerable.Empty<TModel>();

            var model = _mapper.Map<TModel[]>(entities);

            return model;
        }

        public async void RemoveAsync(TModel model)
        {
            var entity = await _repositoryBase.Get(model.Id);

            if(entity != null)
                _repositoryBase.RemoveAsync(entity);
        }

        public async Task<TModel> Update(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);            
            var result = await _repositoryBase.Update(entity);

            return _mapper.Map<TModel>(result);
        }
    }
}
