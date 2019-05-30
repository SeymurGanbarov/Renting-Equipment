using RCE.Application.QueryServices;
using System;
using System.Collections.Generic;
using RCE.Application.DTOs;
using System.Linq;
using AutoMapper;

namespace RCE.Infrastructure.QueryServices
{
    public class ProductQueryService : IProductQueryService
    {
        public IEnumerable<ProductDTO> GetAll() => DataContext.Products.Select(m => Mapper.Map<ProductDTO>(m));
    }
}
