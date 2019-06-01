using System;
using System.Collections.Generic;
using RCE.Application.BusinessLogics;
using RCE.Application.DTOs;
using RCE.Commons;

namespace RCE.Application.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeBusinessLogic _productTypeBusinessLogic;

        public ProductTypeService(IProductTypeBusinessLogic productTypeBusinessLogic)
        {
            _productTypeBusinessLogic = productTypeBusinessLogic;
        }

        public LogicResult<IEnumerable<ProductTypeDTO>> GetAll()
        {
            try
            {
                var users = _productTypeBusinessLogic.GetAll();
                return LogicResult<IEnumerable<ProductTypeDTO>>.Succeed(users);
            }
            catch (Exception exception)
            {
                return LogicResult<IEnumerable<ProductTypeDTO>>.Failure(exception);
            }
        }

        public LogicResult<ProductTypeDTO> GetById(Guid id)
        {
            try
            {
                var entity = _productTypeBusinessLogic.GetById(id);
                return LogicResult<ProductTypeDTO>.Succeed(entity);
            }
            catch (Exception exception)
            {
                return LogicResult<ProductTypeDTO>.Failure(exception);
            }
        }

        public LogicResult Remove(Guid id)
        {
            try
            {
                _productTypeBusinessLogic.Remove(id);
                return LogicResult.Succeed();
            }
            catch (Exception exception)
            {
                return LogicResult.Failure(exception);
            }
        }

        public LogicResult<ProductTypeDTO> Save(ProductTypeDTO entity)
        {
            try
            {
                var dto= _productTypeBusinessLogic.Save(entity);
                return LogicResult<ProductTypeDTO>.Succeed(dto);
            }
            catch (Exception exception)
            {
                return LogicResult<ProductTypeDTO>.Failure(exception);
            }
        }
    }
}
