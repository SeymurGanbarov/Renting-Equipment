using System;
using System.Linq;
using AutoMapper;
using RCE.Application.Repositories;
using RCE.Commons.Extensions;
using RCE.Domain;
using RCE.Infrastructure.DAOs;

namespace RCE.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User FindById(Guid id)
        {
            var entity = DataContext.Users.FirstOrDefault(m => m.Id == id);
            if (entity != null) return Mapper.Map<User>(entity);
            else return null;
        }

        public void Remove(Guid id)
        {
            var entity = DataContext.Users.FirstOrDefault(m => m.Id == id);
            if (entity != null) DataContext.Users.Remove(entity);
        }

        public User Save(User entity)
        {
            if (entity.Id == Guid.Empty)
            {
                var dao = Mapper.Map<UserDAO>(entity);
                dao.InitializeEntity();
                DataContext.Users.Add(dao);
                return Mapper.Map<User>(dao);
            }
            else
            {
                var oldEntity = DataContext.Users.FirstOrDefault(m => m.Id == entity.Id);
                oldEntity.ChangeTo(entity);
                return entity;
            }
        }
    }
}
