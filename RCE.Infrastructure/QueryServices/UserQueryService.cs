using RCE.Application.QueryServices;
using System.Collections.Generic;
using System.Linq;
using RCE.Application.DTOs;
using AutoMapper;

namespace RCE.Infrastructure.QueryServices
{
    public class UserQueryService : IUserQueryService
    {
        public IEnumerable<UserDTO> GetAll() => DataContext.Users.Select(m => Mapper.Map<UserDTO>(m));
    }
}
