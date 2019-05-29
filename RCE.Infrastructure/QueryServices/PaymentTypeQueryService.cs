using System.Collections.Generic;
using RCE.Application.DTOs;
using RCE.Application.QueryServices;
using System.Linq;

namespace RCE.Infrastructure.QueryServices
{
    public class PaymentTypeQueryService : IPaymentTypeQueryService
    {
        public IEnumerable<PaymentTypeDTO> GetAll()
        {
            return DataContext.PaymentTypes.Select(m => new PaymentTypeDTO
            {
                Id=m.Id,
                Type=m.Type,
                Amount=m.Amount,
                Currency=m.Currency
            });
        }
    }
}
