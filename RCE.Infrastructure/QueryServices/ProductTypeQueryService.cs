using RCE.Application.QueryServices;
using System.Collections.Generic;
using System.Linq;
using RCE.Application.DTOs;
using AutoMapper;

namespace RCE.Infrastructure.QueryServices
{
    public class ProductTypeQueryService : IProductTypeQueryService
    {
        public IEnumerable<ProductTypeDTO> GetAll() => DataContext.ProductTypes.Select(m => Mapper.Map<ProductTypeDTO>(m));
    }
}
