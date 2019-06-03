using RCE.Application.DTOs;
using RCE.Application.Services;
using RCE.Commons;
using System;
using System.Collections.Generic;

namespace RCE.UI.Services
{
    public class ProductTypeServiceFacade
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeServiceFacade(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        public IEnumerable<ProductTypeDTO> Data
        {
            get
            {
                var result= _productTypeService.GetAll();
                return result.Data;
            }
        }

        public LogicResult<ProductTypeDTO> GetById(Guid id)
        {
            return _productTypeService.GetById(id);
        }
    }
}