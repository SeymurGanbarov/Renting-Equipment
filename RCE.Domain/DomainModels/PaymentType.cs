using RCE.Commons.Abstracts;

namespace RCE.Domain
{
    public class PaymentType : BaseEntity
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
