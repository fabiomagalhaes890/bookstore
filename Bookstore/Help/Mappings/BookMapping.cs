using Bookstore.Domain.Books;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Help.Mappings
{
    public class BookMapping : EntityBaseMapping<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).IsRequired();
        }
    }
}
