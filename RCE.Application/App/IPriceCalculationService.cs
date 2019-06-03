using RCE.Commons;

namespace RCE.Application.App
{
    public interface IPriceCalculationService
    {
        LogicResult<PaymentDetail> CalculatePrice(PriceDetail priceDetail); 
    }
}
