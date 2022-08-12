using Bookstore.Domain.Books;

namespace Bookstore.Application.Books
{
    public interface IBookApplicationService : IApplicationServiceBase<BookDto, Book>
    {
    }
}
