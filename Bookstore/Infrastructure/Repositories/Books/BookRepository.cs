using Bookstore.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Repositories.Books
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(DbContext context) : base(context) { }
    }
}
