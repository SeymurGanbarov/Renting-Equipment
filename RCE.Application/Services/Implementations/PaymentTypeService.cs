using RCE.Application.BusinessLogics;
using RCE.Application.DTOs;
using RCE.Commons;
using System;
using System.Collections.Generic;

namespace RCE.Application.Services
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IPaymentTypeBusinessLogic _paymentTypeBusinessLogic;

        public PaymentTypeService(IPaymentTypeBusinessLogic paymentTypeBusinessLogic)
        {
            _paymentTypeBusinessLogic = paymentTypeBusinessLogic;
        }

        public LogicResult<IEnumerable<PaymentTypeDTO>> GetAll()
        {
            try
            {
                var users = _paymentTypeBusinessLogic.GetAll();
                return LogicResult<IEnumerable<PaymentTypeDTO>>.Succeed(users);
            }
            catch (Exception exception)
            {
                return LogicResult<IEnumerable<PaymentTypeDTO>>.Failure(exception);
            }
        }

        public LogicResult<PaymentTypeDTO> GetById(Guid id)
        {
            try
            {
                var entity = _paymentTypeBusinessLogic.GetById(id);
                return LogicResult<PaymentTypeDTO>.Succeed(entity);
            }
            catch (Exception exception)
            {
                return LogicResult<PaymentTypeDTO>.Failure(exception);
            }
        }

        public LogicResult Remove(Guid id)
        {
            try
            {
                _paymentTypeBusinessLogic.Remove(id);
                return LogicResult.Succeed();
            }
            catch (Exception exception)
            {
                return LogicResult.Failure(exception);
            }
        }

        public LogicResult Save(PaymentTypeDTO entity)
        {
            try
            {
                _paymentTypeBusinessLogic.Save(entity);
                return LogicResult.Succeed();
            }
            catch (Exception exception)
            {
                return LogicResult.Failure(exception);
            }
        }
    }
}
