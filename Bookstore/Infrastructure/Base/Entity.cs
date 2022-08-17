using AutoMapper.Configuration.Annotations;

namespace Bookstore.Infrastructure.Base
{
    public class Entity
    {
        [SourceMember("Id")]
        public Guid Id { get; protected set; }
        public void SetId(Guid id) => Id = id;
    }
}
