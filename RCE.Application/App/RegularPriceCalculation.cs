using System.Linq;
using RCE.Application.QueryServices;

namespace RCE.Application.App
{
    public class RegularPriceCalculation : IPriceCalculation
    {
        private IPaymentTypeQueryService _paymentTypeQueryService;
        public RegularPriceCalculation(IPaymentTypeQueryService paymentTypeQueryService)
        {
            _paymentTypeQueryService = paymentTypeQueryService;
        }
        public PaymentDetail CalculatePrice(PriceDetail priceDetail)
        {
            var oneTime = _paymentTypeQueryService.GetAll().FirstOrDefault(m => m.Type == PaymentType.OneTime.ToString()).Amount;
            var premiumDailyAmount = _paymentTypeQueryService.GetAll().FirstOrDefault(m => m.Type == PaymentType.Premium.ToString()).Amount;
            var regularDailyAmount = _paymentTypeQueryService.GetAll().FirstOrDefault(m => m.Type == PaymentType.Regular.ToString()).Amount;
            var paymentDetail = new PaymentDetail { OneTime=oneTime };
            var dayOver = PaymentTypeDayOver.Regular;

            if(priceDetail.Day > dayOver)
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
