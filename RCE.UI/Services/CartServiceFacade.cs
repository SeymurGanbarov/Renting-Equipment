using AutoMapper;
using Common.Util;
using RCE.Application.App;
using RCE.Application.DTOs;
using RCE.Application.QueryServices;
using RCE.Application.Services;
using RCE.Commons;
using RCE.UI.Models;
using RCE.UI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RCE.UI.Services
{
    public class CartServiceFacade
    {
        private readonly IProductQueryService _productQueryService;
        private readonly IProductTypeQueryService _productTypeQueryService;
        private readonly IPaymentTypeQueryService _paymentTypeQueryService;
        private readonly IPriceCalculationService _priceCalculationService;
        private readonly IUserToProductService _userToProductService;


        public CartServiceFacade(IProductQueryService productQueryService, IProductTypeQueryService productTypeQueryService,
                                 IPaymentTypeQueryService paymentTypeQueryService, IPriceCalculationService priceCalculationService,
                                 IUserToProductService userToProductService)
        {
            _paymentTypeQueryService = paymentTypeQueryService;
            _productTypeQueryService = productTypeQueryService;
            _productQueryService = productQueryService;
            _priceCalculationService = priceCalculationService;
            _userToProductService = userToProductService;
        }

        public int DataCount => Store.CartProducts.Count;

        public LogicResult<ProductCartModel> GetProductDetailForAddToCart(Guid productId)
        {
            try
            {
                var model = (from product in _productQueryService.GetAll()
                             join productType in _productTypeQueryService.GetAll() on product.TypeId equals productType.Id
                             where product.Id == productId
                             select new ProductCartModel { Id=product.Id, Name = product.Name, Type = productType.Type, Point=productType.Point, UserId=CurrentUser.Id }).FirstOrDefault();
                var priceDetail = new PriceDetail
                {
                    Type = model.Type.ToEnum<ProductType>()
                };
                var paymentDetailResult = _priceCalculationService.CalculatePrice(priceDetail);
                if (paymentDetailResult.IsSucceed)
                {
                    model.PaymentDetail = paymentDetailResult.Data;
                    return LogicResult<ProductCartModel>.Succeed(model);
                }
                else return LogicResult<ProductCartModel>.Failure(Validation.UnSuccessfullOperation);
            }
            catch
            {
                return LogicResult<ProductCartModel>.Failure(Validation.UnSuccessfullOperation);
            }
        }

        public LogicResult<ProductInvoiceModel> GetProductInvoice(Guid productId)
        {
            try
            {
                var product = Store.CartProducts.FirstOrDefault(m => m.Id == productId);
                return LogicResult<ProductInvoiceModel>.Succeed(Mapper.Map<ProductInvoiceModel>(product));
            }
            catch
            {
                return LogicResult<ProductInvoiceModel>.Failure(Validation.UnSuccessfullOperation);
            }
        }

        public LogicResult Save(ProductInvoiceModel model)
        {
            try
            {
                var dto = new UserToProductDTO
                {
                    Amount = model.PaymentDetail.TotalPrice,
                    UserId = CurrentUser.Id,
                    PaymentDetail = SerializerHelper.Serialize(model.PaymentDetail),
                    Day = model.Day,
                    ProductId = model.Id,
                    Point = model.Point,
                };
                var result = _userToProductService.Save(dto);
                if (result.IsSucceed)
                {
                    var product = Store.CartProducts.FirstOrDefault(m => m.Id == model.Id);
                    Store.CartProducts.Remove(product);
                    return LogicResult.Succeed();
                }
                else return LogicResult.Failure(Validation.UnSuccessfullOperation);
            }
            catch
            {
                return LogicResult<int>.Failure(Validation.UnSuccessfullOperation);
            }
        }

        public LogicResult<IEnumerable<ProductCartModel>> GetProducts()
        {
            try
            {
                return LogicResult<IEnumerable<ProductCartModel>>.Succeed(Store.CartProducts.Where(m=>m.UserId==CurrentUser.Id));
            }
            catch
            {
                return LogicResult<IEnumerable<ProductCartModel>>.Failure(Validation.UnSuccessfullOperation);
            }

        }

        public LogicResult<PaymentDetail> CalculatePrice(PriceDetail priceDetail)
        {
            var paymentDetailResult = _priceCalculationService.CalculatePrice(priceDetail);
            if (paymentDetailResult.IsSucceed)
                return LogicResult<PaymentDetail>.Succeed(paymentDetailResult.Data);
            else return LogicResult<PaymentDetail>.Failure(Validation.UnSuccessfullOperation);
        }

        public LogicResult<int> AddToCart(ProductCartModel model)
        {
            if (Store.CartProducts.Any(m => m.Id == model.Id && m.UserId == model.UserId)) return LogicResult<int>.Failure(Validation.PrductExistInCart);
            if (model.Day <= 0) return LogicResult<int>.Failure(Validation.MustBeHigherThanZero);
            var priceDetail = new PriceDetail
            {
                Day = model.Day,
                Type = model.Type.ToEnum<ProductType>()
            };
            var paymentDetailResult = _priceCalculationService.CalculatePrice(priceDetail);
            if (paymentDetailResult.IsSucceed)
            {
                model.PaymentDetail = paymentDetailResult.Data;
                Store.CartProducts.Add(model);
                return LogicResult<int>.Succeed(DataCount);
            }
            else return LogicResult<int>.Failure(Validation.UnSuccessfullOperation);
        }
    }
}