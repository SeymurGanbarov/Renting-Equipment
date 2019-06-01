using System;
using System.Collections.Generic;
using AutoMapper;
using RCE.Application.DTOs;
using RCE.Application.QueryServices;
using RCE.Application.Repositories;
using RCE.Domain;

namespace RCE.Application.BusinessLogics
{
    public class BaseProductBusinessLogic : IProductBusinessLogic
    {
        private readonly IProductQueryService _productQueryService;
        private readonly IProductRepository _productRepository;

        public BaseProductBusinessLogic(IProductQueryService productQueryService,IProductRepository productRepository)
        {
            _productQueryService = productQueryService;
            _productRepository = productRepository;
        }

        public virtual IEnumerable<ProductDTO> GetAll()
        {
            return _productQueryService.GetAll();
        }

        public virtual ProductDTO GetById(Guid id)
        {
            var entity = _productRepository.FindById(id);
            return Mapper.Map<ProductDTO>(entity);
        }

        public virtual void Remove(Guid id)
        {
            _productRepository.Remove(id);
        }

        public virtual ProductDTO Save(ProductDTO dto)
        {
            var entity = Mapper.Map<Product>(dto);
            var savedItem= _productRepository.Save(entity);
            return Mapper.Map<ProductDTO>(savedItem);
        }
    }
}
