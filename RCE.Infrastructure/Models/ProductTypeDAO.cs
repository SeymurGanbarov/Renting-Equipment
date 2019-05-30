using RCE.Commons.Abstracts;

namespace RCE.Infrastructure.DAOs
{
    public class ProductTypeDAO : BaseEntityDAO
    {
        public string Type { get; set; }
        public byte Point { get; set; }
    }
}