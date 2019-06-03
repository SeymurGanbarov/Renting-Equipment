using RCE.Application.QueryServices;
using System.Linq;

namespace RCE.Application.App
{
    public class HeavyPriceCalculation : IPriceCalculation
    {
        private IPaymentTypeQueryService _paymentTypeQueryService;
        public HeavyPriceCalculation(IPaymentTypeQueryService paymentTypeQueryService)
        {
            _paymentTypeQueryService = paymentTypeQueryService;
        }
        public PaymentDetail CalculatePrice(PriceDetail priceDetail)
        {
            var oneTime = _paymentTypeQueryService.GetAll().FirstOrDefault(m => m.Type == PaymentType.OneTime.ToString()).Amount;
            var dailyAmount = _paymentTypeQueryService.GetAll().FirstOrDefault(m => m.Type == PaymentType.Premium.ToString()).Amount;
            var dailyPrice = priceDetail.Day * dailyAmount;

            return new PaymentDetail { OneTime = oneTime, Premium = dailyPrice };
        }
    }
}
