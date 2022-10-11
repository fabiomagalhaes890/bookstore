using AutoMapper;
using Bookstore.Domain.Books;
using Bookstore.Help.Configs;
using Bookstore.Help.Configurations.Commands;
using Bookstore.Infrastructure.Repositories;

namespace Bookstore.Application.Books.UpdateBooks
{
    public class UpdateBookCommandHandler : ICommandHandler<UpdateBookCommand>
    {
        private readonly IRepositoryBase<Book> _repository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(
            IRepositoryBase<Book> repository)
        {
            _repository = repository;
            _mapper = ConfigurationMap.CreateMap();
        }

        public void Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            _repository.Update(book);
        }
    }
}
