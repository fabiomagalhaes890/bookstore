using Bookstore.Application.Books.GetBooksDetails;
using Bookstore.Help.Configurations.Commands;

namespace Bookstore.Application.Books.CreateBooks
{
    public class RegisterBookCommand : CommandBase<BookDto>
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public RegisterBookCommand(string? name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
