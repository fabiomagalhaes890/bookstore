using Bookstore.Infrastructure.Models;

namespace Bookstore.Application.Books
{
    public class BookDto : Model
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}