using System;
using System.Linq;
using AutoMapper;
using RCE.Application.Repositories;
using RCE.Commons.Extensions;
using RCE.Domain;
using RCE.Infrastructure.DAOs;

namespace RCE.Infrastructure.Repositories
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        public PaymentType FindById(Guid id)
        {
            var entity= DataContext.PaymentTypes.FirstOrDefault(m => m.Id == id);
            if (entity != null) return Mapper.Map<PaymentType>(entity);
            else return null;
        }

        public void Remove(Guid id)
        {
            var entity = DataContext.PaymentTypes.FirstOrDefault(m => m.Id == id);
            if(entity !=null) DataContext.PaymentTypes.Remove(entity);
        }

        public void Save(PaymentType entity)
        {
            if (entity.Id == Guid.Empty)
            {
                var dao = Mapper.Map<PaymentTypeDAO>(entity);
                dao.InitializeEntity();
                DataContext.PaymentTypes.Add(dao);
            }
            else
            {
                var oldEntity = DataContext.PaymentTypes.FirstOrDefault(m => m.Id == entity.Id);
                oldEntity.ChangeTo(entity);
            }
        }
    }
}
