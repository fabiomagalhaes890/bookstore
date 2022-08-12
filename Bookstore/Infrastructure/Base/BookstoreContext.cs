using Bookstore.Help.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Base
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookMapping());

            base.OnModelCreating(builder);
        }
    }
}
