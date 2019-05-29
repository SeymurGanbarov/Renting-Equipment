using RCE.Commons.Abstracts;

namespace RCE.Infrastructure.DAOs
{
    public class PaymentTypeDAO : BaseEntityDAO
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
