using RCE.Commons.Abstracts;

namespace RCE.Infrastructure.Entities
{
    public class PaymentType : BaseEntity
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
