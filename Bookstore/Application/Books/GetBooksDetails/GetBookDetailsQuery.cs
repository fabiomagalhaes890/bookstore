using Bookstore.Application.Responses;
using Bookstore.Help.Configurations.Queries;

namespace Bookstore.Application.Books.GetBooksDetails
{
    public class GetBookDetailsQuery : IQuery<BookResponse>
    {
        public GetBookDetailsQuery(Guid bookId)
        {
            BookId = bookId;
        }

        public Guid BookId { get; set; }
    }
}
