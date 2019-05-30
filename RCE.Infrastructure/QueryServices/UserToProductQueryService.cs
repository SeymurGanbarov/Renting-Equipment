using RCE.Application.QueryServices;
using System.Collections.Generic;
using System.Linq;
using RCE.Application.DTOs;
using AutoMapper;

namespace RCE.Infrastructure.QueryServices
{
    public class UserToProductQueryService : IUserToProductQueryService
    {
        public IEnumerable<UserToProductDTO> GetAll()
        {
            return DataContext.UserToProducts.Select(m=>Mapper.Map<UserToProductDTO>(m));
        }
    }
}
