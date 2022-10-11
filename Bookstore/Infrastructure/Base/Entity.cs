using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Infrastructure.Base
{
    public class Entity
    {
        [Key]
        [Column("Id")]
        [SourceMember("Id")]
        public Guid Id { get; protected set; }
        public void SetId(Guid id) => Id = id;
    }
}
