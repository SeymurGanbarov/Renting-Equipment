
using RCE.Commons.Abstracts;

namespace RCE.Domain
{
    public class ProductType : BaseEntity
    {
        public string Type { get; set; }
        public byte Point { get; set; }
    }
}