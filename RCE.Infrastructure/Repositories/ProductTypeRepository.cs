using System;
using System.Linq;
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
            if (entity != null) return new ProductType { Id=entity.Id,Point=entity.Point,Type=entity.Type};
            else return null;
        }

        public void Remove(Guid id)
        {
            var entity = DataContext.ProductTypes.FirstOrDefault(m => m.Id == id);
            if (entity != null) DataContext.ProductTypes.Remove(entity);
        }

        public void Save(ProductType entity)
        {
            if (entity.Id == Guid.Empty)
            {
                var dao = new ProductTypeDAO { Point = entity.Point, Type = entity.Type };
                dao.InitializeEntity();
                DataContext.ProductTypes.Add(dao);
            }
            else
            {
                var oldEntity = DataContext.ProductTypes.FirstOrDefault(m => m.Id == entity.Id);
                oldEntity.ChangeTo(entity);
            }

        }
    }
}
