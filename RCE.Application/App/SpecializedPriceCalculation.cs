using RCE.Application.QueryServices;
using System.Linq;

namespace RCE.Application.App
{
    public class SpecializedPriceCalculation : IPriceCalculation
    {
        private IPaymentTypeQueryService _paymentTypeQueryService;
        public SpecializedPriceCalculation(IPaymentTypeQueryService paymentTypeQueryService)
        {
            _paymentTypeQueryService = paymentTypeQueryService;
        }

        public PaymentDetail CalculatePrice(PriceDetail priceDetail)
        {
            var premiumDailyAmount = _paymentTypeQueryService.GetAll().FirstOrDefault(m => m.Type == PaymentType.Premium.ToString()).Amount;
            var regularDailyAmount = _paymentTypeQueryService.GetAll().FirstOrDefault(m => m.Type == PaymentType.Regular.ToString()).Amount;
            var paymentDetail = new PaymentDetail();
            var dayOver = PaymentTypeDayOver.Specialized;

            if (priceDetail.Day > dayOver)
            {
                paymentDetail.Premium = premiumDailyAmount * dayOver;
                paymentDetail.Regular = regularDailyAmount * (priceDetail.Day - dayOver);

                return paymentDetail;
            }
            else
            {
                paymentDetail.Premium = premiumDailyAmount * priceDetail.Day;
                return paymentDetail;
            }
        }
    }
}
