using System;
using System.Linq;
using RCE.Commons.Extensions;
using RCE.Infrastructure;
using RCE.Infrastructure.Entities;

namespace RCE.Application.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product FindById(Guid id)
        {
            return DataContext.Products.FirstOrDefault(m => m.Id == id);
        }

        public void Remove(Guid id)
        {
            var item = this.FindById(id);
            DataContext.Products.Remove(item);
        }

        public void Save(Product entity)
        {
            if(entity.Id == Guid.Empty)
            {
                entity.InitializeEntity();
                DataContext.Products.Add(entity);
            }
            else
            {
                var oldEntity = this.FindById(entity.Id);
                oldEntity.ChangeTo(entity);
            }
               
        }
    }
}
