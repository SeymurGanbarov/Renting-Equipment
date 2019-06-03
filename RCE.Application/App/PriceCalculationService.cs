using System;
using RCE.Commons;
using RCE.Application.QueryServices;

namespace RCE.Application.App
{
    public class PriceCalculationService : IPriceCalculationService
    {
        private readonly IPaymentTypeQueryService _paymentTypeQueryService;
        public PriceCalculationService(IPaymentTypeQueryService paymentTypeQueryService)
        {
            _paymentTypeQueryService = paymentTypeQueryService;
        }
        public LogicResult<PaymentDetail> CalculatePrice(PriceDetail priceDetail)
        {
            try
            {
                var calculation = this.GetCalculation(priceDetail.Type);
                var paymentDetail = calculation.CalculatePrice(priceDetail);
                return LogicResult<PaymentDetail>.Succeed(paymentDetail);
            }
            catch (Exception exception)
            {
                return LogicResult<PaymentDetail>.Failure(exception);
            }
        }

        private IPriceCalculation GetCalculation(ProductType type)
        {
            switch (type)
            {
                case ProductType.Heavy:
                    return new HeavyPriceCalculation(_paymentTypeQueryService);
                case ProductType.Regular:
                    return new RegularPriceCalculation(_paymentTypeQueryService);
                case ProductType.Specialized:
                    return new SpecializedPriceCalculation(_paymentTypeQueryService);
                default:
                    break;
            }
            return null;
        }
    }
}
