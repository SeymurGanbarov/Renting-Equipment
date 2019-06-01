using System;
using System.Linq;
using AutoMapper;
using RCE.Application.Repositories;
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
            if (entity != null) return Mapper.Map<Product>(entity);
            else return null;
        }

        public void Remove(Guid id)
        {
            var entity = DataContext.Products.FirstOrDefault(m => m.Id == id);
            if (entity != null) DataContext.Products.Remove(entity);
        }

        public Product Save(Product entity)
        {
            if (entity.Id == Guid.Empty)
            {
                var dao = Mapper.Map<ProductDAO>(entity);
                dao.InitializeEntity();
                DataContext.Products.Add(dao);
                return Mapper.Map<Product>(dao);
            }
            else
            {
                var oldEntity = DataContext.Products.FirstOrDefault(m => m.Id == entity.Id);
                oldEntity.ChangeTo(entity);
                return entity;
            }

        }
    }
}
