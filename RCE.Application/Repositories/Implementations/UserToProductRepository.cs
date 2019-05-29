using RCE.Commons.Extensions;
using RCE.Infrastructure;
using RCE.Infrastructure.Entities;
using System;
using System.Linq;

namespace RCE.Application.Repositories
{
    public class UserToProductRepository : IUserToProductRepository
    {
        public UserToProduct FindById(Guid id)
        {
            return DataContext.UserToProducts.FirstOrDefault(m => m.Id == id);
        }

        public void Remove(Guid id)
        {
            var entity = this.FindById(id);
            DataContext.UserToProducts.Remove(entity);
        }

        public void Save(UserToProduct entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.InitializeEntity();
                DataContext.UserToProducts.Add(entity);
            }
            else
            {
                var oldEntity = this.FindById(entity.Id);
                oldEntity.ChangeTo(entity);
            }
        }
    }
}
