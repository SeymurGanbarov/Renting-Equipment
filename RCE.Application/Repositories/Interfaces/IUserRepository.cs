using RCE.Commons.Abstracts;
using RCE.Infrastructure.Entities;

namespace RCE.Application.Repositories
{
    public interface IUserRepository : IEntityRepository<User>
    { }
}
