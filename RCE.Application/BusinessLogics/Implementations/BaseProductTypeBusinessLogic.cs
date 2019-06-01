using AutoMapper;
using RCE.Application.DTOs;
using RCE.Application.QueryServices;
using RCE.Application.Repositories;
using RCE.Domain;
using System;
using System.Collections.Generic;

namespace RCE.Application.BusinessLogics
{
    public class BaseProductTypeBusinessLogic : IProductTypeBusinessLogic
    {
        private readonly IProductTypeQueryService _productTypeQueryService;
        private readonly IProductTypeRepository _productTypeRepository;

        public BaseProductTypeBusinessLogic(IProductTypeQueryService productTypeQueryService, IProductTypeRepository productTypeRepository)
        {
            _productTypeQueryService = productTypeQueryService;
            _productTypeRepository = productTypeRepository;
        }

        public virtual IEnumerable<ProductTypeDTO> GetAll()
        {
            return _productTypeQueryService.GetAll();
        }

        public virtual ProductTypeDTO GetById(Guid id)
        {
            var entity = _productTypeRepository.FindById(id);
            return Mapper.Map<ProductTypeDTO>(entity);
        }

        public virtual void Remove(Guid id)
        {
            _productTypeRepository.Remove(id);
        }

        public virtual ProductTypeDTO Save(ProductTypeDTO dto)
        {
            var entity = Mapper.Map<ProductType>(dto);
            var savedItem=_productTypeRepository.Save(entity);
            return Mapper.Map<ProductTypeDTO>(savedItem);
        }
    }
}
