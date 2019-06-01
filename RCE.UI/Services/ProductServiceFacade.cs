using RCE.Application.DTOs;
using RCE.Application.Services;
using System.Collections.Generic;

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
    }
}