using RCE.Commons.Abstracts;

namespace RCE.Application.DTOs
{
    public class ProductTypeDTO : BaseEntityDTO
    {
        public string Type { get; set; }
        public byte Point { get; set; }
    }
}