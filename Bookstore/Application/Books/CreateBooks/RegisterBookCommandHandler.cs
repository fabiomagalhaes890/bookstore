using AutoMapper;
using Bookstore.Application.Books.GetBooksDetails;
using Bookstore.Domain.Books;
using Bookstore.Help.Configs;
using Bookstore.Help.Configurations.Commands;
using Bookstore.Infrastructure.Repositories.Books;

namespace Bookstore.Application.Books.CreateBooks
{
    internal sealed class RegisterBookCommandHandler : ICommandHandler<RegisterBookCommand, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        internal RegisterBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            var configMap = ConfigurationMap.RegisterMappings();
            _mapper = configMap.CreateMapper();
        }

        public async Task<BookDto> Handle(RegisterBookCommand request, CancellationToken cancellationToken)
        {
            var book = Book.Create(request.Name, request.Price);

            var entity = _mapper.Map<Book>(book);
            var result = await _bookRepository.Add(entity);

            return _mapper.Map<BookDto>(result);
        }
    }
}
