using RCE.UI.Models;
using RCE.UI.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace RCE.UI.Controllers
{
    [RCE.UI.Helpers.Authorize]
    public class ProductController : BaseController
    {
        private readonly ProductServiceFacade _productServiceFacade;
        private readonly ProductTypeServiceFacade _productTypeServiceFacade;
        public ProductController(ProductServiceFacade productServiceFacade, ProductTypeServiceFacade productTypeServiceFacade)
        {
            _productServiceFacade = productServiceFacade;
            _productTypeServiceFacade = productTypeServiceFacade;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            var productViewModel = new ProductViewModel
            {
                Products = _productServiceFacade.Data,
                ProductTypes = _productTypeServiceFacade.Data
            };
            return View(productViewModel);
        }

        [HttpGet]
        public ActionResult GetByType(Guid typeId)
        {
            var result= _productServiceFacade.GetByTypeId(typeId);
            if (result.IsSucceed) return PartialView("_ListPartial", result.Data);
            else return AjaxFailureResult(result);
        }
    }
}