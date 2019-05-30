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

        public LogicResult<IEnumerable<ProductTypeDTO>> Data
        {
            get
            {
                return _productTypeService.GetAll();
            }
        }

        public LogicResult<ProductTypeDTO> GetById(Guid id)
        {
            return _productTypeService.GetById(id);
        }

        public LogicResult Save(ProductTypeDTO dto)
        {
            return _productTypeService.Save(dto);
        }

        public LogicResult Remove(Guid id)
        {
            return _productTypeService.Remove(id);
        }
    }
}