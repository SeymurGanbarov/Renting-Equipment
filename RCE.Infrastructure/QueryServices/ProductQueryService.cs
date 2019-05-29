using RCE.Application.QueryServices;
using System;
using System.Collections.Generic;
using RCE.Application.DTOs;
using System.Linq;

namespace RCE.Infrastructure.QueryServices
{
    public class ProductQueryService : IProductQueryService
    {
        public IEnumerable<ProductDTO> GetAll()
        {
            return DataContext.Products.Select(m => new ProductDTO
            {
                Id=m.Id,
                TypeId=m.TypeId,
                Name=m.Name,
                CreatedDate=m.CreatedDate
            });
        }
    }
}
