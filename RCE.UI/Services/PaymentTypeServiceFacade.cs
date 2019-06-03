using RCE.Application.DTOs;
using RCE.Application.QueryServices;
using RCE.Application.Services;
using RCE.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCE.UI.Services
{
    public class PaymentTypeServiceFacade
    {
        private readonly IPaymentTypeQueryService _paymentTypeQueryService;
        private readonly ICacheService _cacheService;

        public PaymentTypeServiceFacade(IPaymentTypeQueryService paymentTypeQueryService, ICacheService cacheService)
        {
            _paymentTypeQueryService = paymentTypeQueryService;
            _cacheService = cacheService;
        }

        public IEnumerable<PaymentTypeDTO> Data
        {
            get
            {
                return _cacheService.GetOrSet<IEnumerable<PaymentTypeDTO>>("PaymentTypes", () => _paymentTypeQueryService.GetAll());
            }
        }
    }
}