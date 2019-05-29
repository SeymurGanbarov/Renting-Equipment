using System;
using System.Linq;
using RCE.Commons.Extensions;
using RCE.Domain;
using RCE.Infrastructure.DAOs;

namespace RCE.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product FindById(Guid id)
        {
            var entity = DataContext.Products.FirstOrDefault(m => m.Id == id);
            if (entity != null) return new Product { Id=entity.Id,CreatedDate=entity.CreatedDate,Name=entity.Name,TypeId=entity.TypeId};
            else return null;
        }

        public void Remove(Guid id)
        {
            var entity = DataContext.Products.FirstOrDefault(m => m.Id == id);
            if (entity != null) DataContext.Products.Remove(entity);
        }

        public void Save(Product entity)
        {
            if (entity.Id == Guid.Empty)
            {
                var dao = new ProductDAO { Id = entity.Id, CreatedDate = entity.CreatedDate, Name = entity.Name, TypeId = entity.TypeId };
                dao.InitializeEntity();
                DataContext.Products.Add(dao);
            }
            else
            {
                var oldEntity = DataContext.Products.FirstOrDefault(m => m.Id == entity.Id);
                oldEntity.ChangeTo(entity);
            }

        }
    }
}
