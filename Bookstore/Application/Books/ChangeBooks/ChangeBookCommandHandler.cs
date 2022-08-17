using Bookstore.Domain.Books;
using Bookstore.Help.Configurations.Commands;
using Bookstore.Infrastructure.Data;
using Bookstore.Infrastructure.Repositories.Books;
using Dapper;
using MediatR;

namespace Bookstore.Application.Books.ChangeBooks
{
    internal sealed class ChangeBookCommandHandler : ICommandHandler<ChangeBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ChangeBookCommandHandler(
            IBookRepository bookRepository, 
            ISqlConnectionFactory sqlConnectionFactory)
        {
            _bookRepository = bookRepository;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Unit> Handle(ChangeBookCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT " +
                               "[b].[Name], " +
                               "[b].[Price] " +
                               "FROM Book AS [b] " +
                               "WHERE [b].Id = @BookId";

            var book = await connection.QuerySingleAsync<Book>(sql, new { request.BookId });

            book.Update(request.Name, request.Price);
            await _bookRepository.Update(book);            

            return Unit.Value;
        }
    }
}
