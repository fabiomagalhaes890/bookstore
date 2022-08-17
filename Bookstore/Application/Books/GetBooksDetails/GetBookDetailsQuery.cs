using Bookstore.Help.Configurations.Queries;

namespace Bookstore.Application.Books.GetBooksDetails
{
    public class GetBookDetailsQuery : IQuery<List<BookDto>>
    {
        public GetBookDetailsQuery(Guid bookId)
        {
            BookId = bookId;
        }

        public Guid? BookId { get; set; }
    }
}
