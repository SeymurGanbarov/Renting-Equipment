namespace RCE.Application.App
{
    public class PaymentDetail
    {
        public decimal OneTime { get; set; }
        public decimal Premium { get; set; }
        public decimal Regular { get; set; }

        public decimal TotalPrice => OneTime + Premium + Regular;
    }
}
