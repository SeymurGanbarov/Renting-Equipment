using System;
using System.Collections.Generic;
using AutoMapper;
using RCE.Application.DTOs;
using RCE.Application.QueryServices;
using RCE.Application.Repositories;
using RCE.Domain;

namespace RCE.Application.BusinessLogics
{
    public class BasePaymentTypeBusinessLogic : IPaymentTypeBusinessLogic
    {
        private readonly IPaymentTypeQueryService _paymentTypeQueryService;
        private readonly IPaymentTypeRepository _paymentTypeRepository;

        public BasePaymentTypeBusinessLogic(IPaymentTypeQueryService paymentTypeQueryService, IPaymentTypeRepository paymentTypeRepository)
        {
            _paymentTypeQueryService = paymentTypeQueryService;
            _paymentTypeRepository = paymentTypeRepository;
        }

        public virtual IEnumerable<PaymentTypeDTO> GetAll()
        {
            return _paymentTypeQueryService.GetAll();
        }

        public virtual PaymentTypeDTO GetById(Guid id)
        {
            var entity = _paymentTypeRepository.FindById(id);
            return Mapper.Map<PaymentTypeDTO>(entity);
        }

        public virtual void Remove(Guid id)
        {
            _paymentTypeRepository.Remove(id);
        }

        public virtual void Save(PaymentTypeDTO dto)
        {
            var entity = Mapper.Map<PaymentType>(dto);
            _paymentTypeRepository.Save(entity);
        }
    }
}
