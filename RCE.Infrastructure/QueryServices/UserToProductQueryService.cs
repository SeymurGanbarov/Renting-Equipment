using RCE.Application.QueryServices;
using System.Collections.Generic;
using System.Linq;
using RCE.Application.DTOs;

namespace RCE.Infrastructure.QueryServices
{
    public class UserToProductQueryService : IUserToProductQueryService
    {
        public IEnumerable<UserToProductDTO> GetAll()
        {
            return DataContext.UserToProducts.Select(m => new UserToProductDTO
            {
                Id=m.Id,
                UserId=m.UserId,
                ProductId=m.ProductId,
                Day=m.Day,
                Amount=m.Amount,
                PaymentDetail=m.PaymentDetail,
                Point=m.Point,
                CreatedDate=m.CreatedDate
            });
        }
    }
}
