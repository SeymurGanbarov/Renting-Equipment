using AutoMapper;
using RCE.Application.Repositories;
using RCE.Commons.Extensions;
using RCE.Domain;
using RCE.Infrastructure.DAOs;
using System;
using System.Linq;

namespace RCE.Infrastructure.Repositories
{
    public class UserToProductRepository : IUserToProductRepository
    {
        public UserToProduct FindById(Guid id)
        {
            var entity = DataContext.UserToProducts.FirstOrDefault(m => m.Id == id);
            if (entity != null) return Mapper.Map<UserToProduct>(entity);
            else return null;
        }

        public void Remove(Guid id)
        {
            var entity = DataContext.UserToProducts.FirstOrDefault(m => m.Id == id);
            if (entity != null) DataContext.UserToProducts.Remove(entity);
        }

        public void Save(UserToProduct entity)
        {
            if (entity.Id == Guid.Empty)
            {
                var dao = Mapper.Map<UserToProductDAO>(entity);
                dao.InitializeEntity();
                DataContext.UserToProducts.Add(dao);
            }
            else
            {
                var oldEntity = DataContext.UserToProducts.FirstOrDefault(m => m.Id == entity.Id);
                oldEntity.ChangeTo(entity);
            }
        }
    }
}
