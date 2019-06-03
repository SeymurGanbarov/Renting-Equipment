using RCE.Application.App;
using RCE.UI.Models;
using RCE.UI.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RCE.UI.Controllers
{
    [RCE.UI.Helpers.Authorize]
    public class CartController : BaseController
    {
        private readonly CartServiceFacade _cartServiceFacade;
        public CartController(CartServiceFacade cartServiceFacade)
        {
            _cartServiceFacade = cartServiceFacade;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var result = _cartServiceFacade.GetProducts();
            if (result.IsSucceed)
                return View(result.Data);
            else
                return View(new List<ProductCartModel>());
        }

        [HttpGet]
        public ActionResult CartProductsCount(string returnUrl)
        {
            return View(_cartServiceFacade.DataCount);
        }

        [HttpGet]
        public ActionResult Add(Guid productId)
        {
            var result = _cartServiceFacade.GetProductDetailForAddToCart(productId);
            if (result.IsSucceed)
                return PartialView("_FormPartial", result.Data);
            else
                return AjaxFailureResult(result);
        }

        [HttpGet]
        public ActionResult GetInvoice(Guid productId)
        {
            var result = _cartServiceFacade.GetProductInvoice(productId);
            if (result.IsSucceed)
                return PartialView("_InvoicePartial", result.Data);
            else
                return AjaxFailureResult(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductCartModel model)
        {
            var result = _cartServiceFacade.AddToCart(model);
            if (result.IsSucceed)
                return Json(new { IsSucceed = result.IsSucceed, Count=result.Data }, JsonRequestBehavior.AllowGet);
            else return AjaxFailureResult(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ProductInvoiceModel model)
        {
            var result = _cartServiceFacade.Save(model);
            if (result.IsSucceed)
                return Json(new { IsSucceed = result.IsSucceed}, JsonRequestBehavior.AllowGet);
            else return AjaxFailureResult(result);
        }

        [HttpGet]
        public ActionResult CalculatePrice(PriceDetail priceDetail)
        {
            var result = _cartServiceFacade.CalculatePrice(priceDetail);
            if (result.IsSucceed)
                return Json(result.Data, JsonRequestBehavior.AllowGet);
            else return AjaxFailureResult(result);
        }
    }
}