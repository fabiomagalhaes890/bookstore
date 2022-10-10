using AutoMapper;
using Bookstore.Domain.Books;
using Bookstore.Help.Configs;
using Bookstore.Help.Configurations.Commands;
using Bookstore.Infrastructure.Repositories;

namespace Bookstore.Application.Books.DeleteBooks
{
    public class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand>
    {
        private readonly IRepositoryBase<Book> _repository;
        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(
            IRepositoryBase<Book> repository)
        {
            _repository = repository;
            _mapper = ConfigurationMap.CreateMap();
        }


        public void Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            _repository.RemoveAsync(book);
        }
    }
}
