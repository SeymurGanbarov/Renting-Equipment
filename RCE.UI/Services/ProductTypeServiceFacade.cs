using RCE.Application.DTOs;
using RCE.Application.Services;
using RCE.Commons;
using RCE.UI.Helpers;
using System;
using System.Collections.Generic;

namespace RCE.UI.Services
{
    public class ProductTypeServiceFacade
    {
        private readonly IProductTypeService _productTypeService;
        private readonly ICacheService _cacheService;

        public ProductTypeServiceFacade(IProductTypeService productTypeService,ICacheService cacheService)
        {
            _productTypeService = productTypeService;
            _cacheService = cacheService;
        }

        public IEnumerable<ProductTypeDTO> Data
        {
            get
            {
                return _cacheService.GetOrSet<IEnumerable<ProductTypeDTO>>("ProductTypes", ()=> _productTypeService.GetAll().Data);
            }
        }

        public LogicResult<ProductTypeDTO> GetById(Guid id)
        {
            return _productTypeService.GetById(id);
        }
    }
}