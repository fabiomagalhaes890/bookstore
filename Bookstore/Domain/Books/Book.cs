using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Bookstore.Application.Books;
using Bookstore.Infrastructure.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Domain.Books
{
    [AutoMap(typeof(BookDto))]
    [Table("Book")]
    public class Book : Entity
    {
        [Required]
        [Column(TypeName = "varchar(200)")]
        [SourceMember(nameof(Book.Name))]
        public virtual string? Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        [SourceMember(nameof(Book.Price))]        
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