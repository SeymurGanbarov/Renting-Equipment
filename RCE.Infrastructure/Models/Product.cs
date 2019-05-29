using RCE.Commons.Abstracts;
using System;

namespace RCE.Infrastructure.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
