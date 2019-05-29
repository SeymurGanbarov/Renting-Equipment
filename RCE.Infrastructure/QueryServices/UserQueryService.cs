using RCE.Application.QueryServices;
using System.Collections.Generic;
using System.Linq;
using RCE.Application.DTOs;

namespace RCE.Infrastructure.QueryServices
{
    public class UserQueryService : IUserQueryService
    {
        public IEnumerable<UserDTO> GetAll()
        {
            return DataContext.Users.Select(m => new UserDTO
            {
                Id=m.Id,
                Name=m.Name,
                Surname=m.Surname,
                Email=m.Email,
                Password=m.Password,
                CreatedDate=m.CreatedDate
            });
        }
    }
}
