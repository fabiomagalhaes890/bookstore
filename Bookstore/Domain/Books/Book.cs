using Bookstore.Infrastructure.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Domain.Books
{
    [Table("Book")]
    public class Book : Entity
    {
        public virtual string? Name { get; set; }

        public virtual decimal Price { get; set; }

        public static Book Create(string? name, decimal price)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (price <= 0)
                    throw new ArgumentException("The Book price must be greather than 0.");

                return new Book()
                {
                    Name = name,
                    Price = price
                };
            }

            throw new ArgumentException("The Book must have name to be registered.");
        }

        public void Update(string? name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}