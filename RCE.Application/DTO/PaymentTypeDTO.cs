using RCE.Commons.Abstracts;

namespace RCE.Application.DTOs
{
    public class PaymentTypeDTO : BaseEntityDTO
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
