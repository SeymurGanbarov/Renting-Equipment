using System.Collections.Generic;
using RCE.Application.DTOs;
using RCE.Application.QueryServices;
using System.Linq;
using AutoMapper;

namespace RCE.Infrastructure.QueryServices
{
    public class PaymentTypeQueryService : IPaymentTypeQueryService
    {
        public IEnumerable<PaymentTypeDTO> GetAll() =>  DataContext.PaymentTypes.Select(m => Mapper.Map<PaymentTypeDTO>(m));
    }
}
