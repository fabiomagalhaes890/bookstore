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
    public class GetBookDetailsQueryHandler : IQueryHandler<GetBookDetailsQuery, BookResponse>
    {
        private readonly IRepositoryBase<Book> _repository;
        private readonly IMapper _mapper;

        public GetBookDetailsQueryHandler(
            IRepositoryBase<Book> repository)
        {
            _repository = repository;
            _mapper = ConfigurationMap.CreateMap();
        }

        public async Task<BookResponse> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.Get(request.BookId);

            try
            {
                var response = _mapper.Map<BookResponse>(entity);
                return response;
            }
            catch (Exception ex)
            {
                throw new MapException("An error was encountered while mapping an entity " + typeof(Book).GetTypeInfo().Name + " to the response.", ex);
            }
        }
    }
}
