using System;
using System.Linq;
using AutoMapper;
using RCE.Application.Repositories;
using RCE.Commons.Extensions;
using RCE.Domain;
using RCE.Infrastructure.DAOs;

namespace RCE.Infrastructure.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        public ProductType FindById(Guid id)
        {
            var entity = DataContext.ProductTypes.FirstOrDefault(m => m.Id == id);
            if (entity != null) return Mapper.Map<ProductType>(entity);
            else return null;
        }

        public void Remove(Guid id)
        {
            var entity = DataContext.ProductTypes.FirstOrDefault(m => m.Id == id);
            if (entity != null) DataContext.ProductTypes.Remove(entity);
        }

        public ProductType Save(ProductType entity)
        {
            if (entity.Id == Guid.Empty)
            {
                var dao = Mapper.Map<ProductTypeDAO>(entity);
                dao.InitializeEntity();
                DataContext.ProductTypes.Add(dao);
                return Mapper.Map<ProductType>(dao);
            }
            else
            {
                var oldEntity = DataContext.ProductTypes.FirstOrDefault(m => m.Id == entity.Id);
                oldEntity.ChangeTo(entity);
                return entity;
            }

        }
    }
}
