namespace Bookstore.Infrastructure.Base
{
    public class Entity
    {
        public Guid Id { get; protected set; }
        public void SetId(Guid id) => Id = id;
    }
}
