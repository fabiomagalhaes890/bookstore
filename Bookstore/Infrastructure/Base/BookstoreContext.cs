using Bookstore.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Base
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> opt) : base(opt) { }

        public DbSet<Book>? Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var assembly = typeof(Book).Assembly;
            builder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
