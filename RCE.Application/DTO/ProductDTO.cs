using RCE.Commons.Abstracts;
using System;

namespace RCE.Application.DTOs
{
    public class ProductDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        public Guid TypeId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
