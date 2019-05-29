using RCE.Application.QueryServices;
using System.Collections.Generic;
using System.Linq;
using RCE.Application.DTOs;

namespace RCE.Infrastructure.QueryServices
{
    public class ProductTypeQueryService : IProductTypeQueryService
    {
        public IEnumerable<ProductTypeDTO> GetAll()
        {
            return DataContext.ProductTypes.Select(m => new ProductTypeDTO
            {
                Id=m.Id,
                Type=m.Type,
                Point=m.Point
            });
        }
    }
}
