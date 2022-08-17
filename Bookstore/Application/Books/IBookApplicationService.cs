using Bookstore.Application.Books.GetBooksDetails;
using Bookstore.Domain.Books;

namespace Bookstore.Application.Books
{
    public interface IBookApplicationService : IApplicationServiceBase<BookDto, Book>
    {
    }
}
