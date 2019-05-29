using System;
using System.Linq;
using RCE.Commons.Extensions;
using RCE.Infrastructure;
using RCE.Infrastructure.Entities;

namespace RCE.Application.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        public ProductType FindById(Guid id)
        {
            return DataContext.ProductTypes.FirstOrDefault(m => m.Id == id);
        }

        public void Remove(Guid id)
        {
            var entity = this.FindById(id);
            DataContext.ProductTypes.Remove(entity);
        }

        public void Save(ProductType entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.InitializeEntity();
                DataContext.ProductTypes.Add(entity);
            }
            else
            {
                var oldEntity = this.FindById(entity.Id);
                oldEntity.ChangeTo(entity);
            }
        }
    }
}
