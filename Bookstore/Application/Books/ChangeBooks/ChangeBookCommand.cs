using Bookstore.Help.Configurations.Commands;
using MediatR;

namespace Bookstore.Application.Books.ChangeBooks
{
    public class ChangeBookCommand : CommandBase<Unit>
    {
        public Guid BookId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public ChangeBookCommand(Guid bookId, string? name, decimal price)
        {
            BookId = bookId;
            Name = name;
            Price = price;
        }
    }
}
