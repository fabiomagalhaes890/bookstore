using Bookstore.Help.Configurations.Commands;
using MediatR;

namespace Bookstore.Application.Books.UpdateBooks
{
    public class UpdateBookCommand : CommandBase
    {
        public Guid BookId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public UpdateBookCommand(Guid bookId, string? name, decimal price)
        {
            BookId = bookId;
            Name = name;
            Price = price;
        }
    }
}
