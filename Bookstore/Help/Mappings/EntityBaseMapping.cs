using Bookstore.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Help.Mappings
{
    public class EntityBaseMapping<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public Guid Id { get; set; }
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
