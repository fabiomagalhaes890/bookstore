using AutoMapper;
using Bookstore.Help.Configs;
using Bookstore.Help.Configurations.Queries;
using Bookstore.Infrastructure.Data;
using Dapper;

namespace Bookstore.Application.Books.GetBooksDetails
{
    public class GetBookDetailsQueryHandler : IQueryHandler<GetBookDetailsQuery, List<BookDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IMapper _mapper;

        public GetBookDetailsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            var configMap = ConfigurationMap.RegisterMappings();
            _mapper = configMap.CreateMapper();
        }

        public async Task<List<BookDto>> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sql = "SELECT " +
                               "[b].[Name], " +
                               "[b].[Price] " +
                               "FROM Book AS [b] ";

            var param = request.BookId == null ? string.Empty : " WHERE [b].Id = @BookId";


            var books = await connection.QueryAsync<BookDto>(sql + param, new { request.BookId });
            return books.ToList();
        }
    }
}
