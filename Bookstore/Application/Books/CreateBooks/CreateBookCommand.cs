using Bookstore.Application.Books.GetBooksDetails;
using Bookstore.Application.Responses;
using Bookstore.Help.Configurations.Commands;

namespace Bookstore.Application.Books.CreateBooks
{
    public class CreateBookCommand : CommandBase<BookResponse>
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public CreateBookCommand(string? name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
