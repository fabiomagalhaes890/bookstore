using Bookstore.Help.Configurations.Commands;
using Bookstore.Infrastructure.Repositories.Books;
using MediatR;

namespace Bookstore.Application.Books.RemoveBooks
{
    internal sealed class RemoveBookCommandHandler : ICommandHandler<RemoveBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        internal RemoveBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            var book = await this._bookRepository.Get(request.BookId);

            if (book != null)
                _bookRepository.RemoveAsync(book);

            return Unit.Value;
        }
    }
}
