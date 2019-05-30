using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCE.Application.BusinessLogics;
using RCE.Application.DTOs;
using RCE.Commons;

namespace RCE.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductBusinessLogic _productBusinessLogic;

        public ProductService(IProductBusinessLogic productBusinessLogic)
        {
            _productBusinessLogic = productBusinessLogic;
        }

        public LogicResult<IEnumerable<ProductDTO>> GetAll()
        {
            try
            {
                var products = _productBusinessLogic.GetAll();
                return LogicResult<IEnumerable<ProductDTO>>.Succeed(products);
            }
            catch (Exception exception)
            {
                return LogicResult<IEnumerable<ProductDTO>>.Failure(exception);
            }
        }

        public LogicResult<ProductDTO> GetById(Guid id)
        {
            try
            {
                var entity = _productBusinessLogic.GetById(id);
                return LogicResult<ProductDTO>.Succeed(entity);
            }
            catch (Exception exception)
            {
                return LogicResult<ProductDTO>.Failure(exception);
            }
        }

        public LogicResult Remove(Guid id)
        {
            try
            {
                _productBusinessLogic.Remove(id);
                return LogicResult.Succeed();
            }
            catch (Exception exception)
            {
                return LogicResult.Failure(exception);
            }
        }

        public LogicResult Save(ProductDTO entity)
        {
            try
            {
                _productBusinessLogic.Save(entity);
                return LogicResult.Succeed();
            }
            catch (Exception exception)
            {
                return LogicResult.Failure(exception);
            }
        }
    }
}
