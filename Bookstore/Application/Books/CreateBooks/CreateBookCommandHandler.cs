using AutoMapper;
using Bookstore.Application.Responses;
using Bookstore.Domain.Books;
using Bookstore.Help.Configs;
using Bookstore.Help.Configurations.Commands;
using Bookstore.Help.Exceptions;
using Bookstore.Infrastructure.Repositories;
using System.Reflection;

namespace Bookstore.Application.Books.CreateBooks
{
    public class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, BookResponse>
    {
        private readonly IRepositoryBase<Book> _repository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(
            IRepositoryBase<Book> repository)
        {
            _repository = repository;
            _mapper = ConfigurationMap.CreateMap();
        }

        public async Task<BookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Book>(request);
            var result = await _repository.Add(entity);
            try
            {
                var response = _mapper.Map<BookResponse>(result);
                return response;
            }
            catch (Exception ex)
            {
                throw new MapException("An error was encountered while mapping an entity " + typeof(Book).GetTypeInfo().Name + " to the response.", ex);
            }
        }
    }
}