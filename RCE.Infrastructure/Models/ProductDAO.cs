using RCE.Commons.Abstracts;
using System;

namespace RCE.Infrastructure.DAOs
{
    public class ProductDAO : BaseEntityDAO
    {
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
