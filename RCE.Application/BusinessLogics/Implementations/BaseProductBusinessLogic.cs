using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCE.Application.DTOs;
using RCE.Application.QueryServices;
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

        public IEnumerable<ProductDTO> GetAll()
        {
            return _productQueryService.GetAll();
        }

        public ProductDTO GetById(Guid id)
        {
            var entity = _productRepository.FindById(id);
            return new ProductDTO { Id = entity.Id, CreatedDate = entity.CreatedDate, Name = entity.Name, TypeId = entity.TypeId };
        }

        public void Remove(Guid id)
        {
            _productRepository.Remove(id);
        }

        public void Save(ProductDTO dto)
        {
            var entity = new Product { Id = dto.Id, CreatedDate = dto.CreatedDate, TypeId = dto.TypeId, Name = dto.Name };
            _productRepository.Save(entity);
        }
    }
}
