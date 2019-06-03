using RCE.Application.DTOs;
using RCE.Application.Services;
using System.Collections.Generic;
using System;
using RCE.Commons;
using System.Linq;

namespace RCE.UI.Services
{
    public class ProductServiceFacade
    {
        private readonly IProductService _productService;
        public ProductServiceFacade(IProductService productService)
        {
            _productService = productService;
        }

        public IEnumerable<ProductDTO> Data
        {
            get
            {
                var result = _productService.GetAll();
                return result.Data;
            }
        }

        public LogicResult<IEnumerable<ProductDTO>> GetByTypeId(Guid typeId)
        {
            var result = _productService.GetAll();
            if (result.IsSucceed)
            {
                var products = result.Data.Where(m => m.TypeId == typeId);
                return LogicResult<IEnumerable<ProductDTO>>.Succeed(products);
            }
            else return LogicResult<IEnumerable<ProductDTO>>.Failure(result.FailureResult.ToArray());
        }
    }
}