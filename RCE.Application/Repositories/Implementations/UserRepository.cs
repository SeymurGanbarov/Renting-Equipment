using System;
using System.Linq;
using RCE.Commons.Extensions;
using RCE.Infrastructure;
using RCE.Infrastructure.Entities;

namespace RCE.Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User FindById(Guid id)
        {
            return DataContext.Users.FirstOrDefault(m => m.Id == id);
        }

        public void Remove(Guid id)
        {
            var item = this.FindById(id);
            DataContext.Users.Remove(item);
        }

        public void Save(User entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.InitializeEntity();
                DataContext.Users.Add(entity);
            }
            else
            {
                var oldEntity = this.FindById(entity.Id);
                oldEntity.ChangeTo(entity);
            }
        }
    }
}
