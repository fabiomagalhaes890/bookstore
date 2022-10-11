using AutoMapper;
using Bookstore.Application.Responses;
using Bookstore.Domain.Books;
using Bookstore.Help.Configs;
using Bookstore.Help.Configurations.Queries;
using Bookstore.Help.Exceptions;
using Bookstore.Infrastructure.Repositories;
using System.Reflection;

namespace Bookstore.Application.Books.GetBooksDetails
{
    public class GetBooksQueryHandler : IQueryHandler<GetBooksQuery, IEnumerable<BookResponse>>
    {
        private readonly IRepositoryBase<Book> _repository;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(
            IRepositoryBase<Book> repository)
        {
            _repository = repository;
            _mapper = ConfigurationMap.CreateMap();
        }

        public async Task<IEnumerable<BookResponse>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll();

            if (entities == null)
                return Enumerable.Empty<BookResponse>();

            try
            {
                var result = _mapper.Map<BookResponse[]>(entities);
                return result;
            }
            catch (Exception ex)
            {
                throw new MapException("An error was encountered while mapping an entity " + typeof(Book).GetTypeInfo().Name + " list to the response.", ex);
            }
        }
    }
}
