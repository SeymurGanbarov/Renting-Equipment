using System;
using System.Linq;
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
            if (entity != null) return new User { Id=entity.Id,CreatedDate=entity.CreatedDate,Email=entity.Email,Name=entity.Name,Password=entity.Password,Surname=entity.Surname };
            else return null;
        }

        public void Remove(Guid id)
        {
            var entity = DataContext.Users.FirstOrDefault(m => m.Id == id);
            if (entity != null) DataContext.Users.Remove(entity);
        }

        public void Save(User entity)
        {
            if (entity.Id == Guid.Empty)
            {
                var dao = new UserDAO { Email = entity.Email, Name = entity.Name, Password = entity.Password, Surname = entity.Surname };
                dao.InitializeEntity();
                DataContext.Users.Add(dao);
            }
            else
            {
                var oldEntity = DataContext.Users.FirstOrDefault(m => m.Id == entity.Id);
                oldEntity.ChangeTo(entity);
            }
        }
    }
}
