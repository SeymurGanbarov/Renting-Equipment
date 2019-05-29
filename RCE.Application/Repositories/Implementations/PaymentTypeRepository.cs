using System;
using System.Linq;
using RCE.Commons.Extensions;
using RCE.Infrastructure;
using RCE.Infrastructure.Entities;

namespace RCE.Application.Repositories
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        public PaymentType FindById(Guid id)
        {
            return DataContext.PaymentTypes.FirstOrDefault(m => m.Id == id);
        }

        public void Remove(Guid id)
        {
            var entity = this.FindById(id);
            DataContext.PaymentTypes.Remove(entity);
        }

        public void Save(PaymentType entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.InitializeEntity();
                DataContext.PaymentTypes.Add(entity);
            }
            else
            {
                var oldEntity = this.FindById(entity.Id);
                oldEntity.ChangeTo(oldEntity);
            }
        }
    }
}
