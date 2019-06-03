using Common.Util;
using RCE.Application.App;
using RCE.Application.QueryServices;
using RCE.Application.Services;
using RCE.Commons;
using RCE.UI.Models;
using RCE.UI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCE.UI.Services
{
    public class CabinetServiceFacade
    {
        private readonly IUserToProductQueryService _userToProductQueryService;
        private readonly IProductTypeQueryService _productTypeQueryService;
        private readonly IProductQueryService _productQueryService;
        public CabinetServiceFacade(IUserToProductQueryService userToProductQueryService, IProductTypeQueryService productTypeQueryService,
                                     IProductQueryService productQueryService)
        {
            _userToProductQueryService = userToProductQueryService;
            _productTypeQueryService = productTypeQueryService;
            _productQueryService = productQueryService;
        }

        public LogicResult<IEnumerable<ProductCartModel>> GetProductsByUser(Guid userId)
        {
            try
            {
                var userProducts =  from userToProduct in _userToProductQueryService.GetAll()
                                    join product in _productQueryService.GetAll() on userToProduct.ProductId equals product.Id
                                    join productType in _productTypeQueryService.GetAll() on product.TypeId equals productType.Id
                                    where userToProduct.UserId == userId select new ProductCartModel
                                    {
                                        Day = userToProduct.Day,
                                        UserId = userToProduct.UserId,
                                        Point = userToProduct.Point,
                                        Id = userToProduct.ProductId,
                                        PaymentDetail = SerializerHelper.DeserializeObject<PaymentDetail>(userToProduct.PaymentDetail),
                                        Name = product.Name,
                                        Type = productType.Type
                                    };
                return LogicResult<IEnumerable<ProductCartModel>>.Succeed(userProducts);
            }
            catch
            {
                return LogicResult<IEnumerable<ProductCartModel>>.Failure(Validation.UnSuccessfullOperation);
            }
        }
    }
}