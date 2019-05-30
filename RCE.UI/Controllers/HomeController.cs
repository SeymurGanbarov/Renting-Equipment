using RCE.Application.DTOs;
using RCE.UI.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RCE.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ProductTypeServiceFacade _productTypeServiceFacade;

        public HomeController(ProductTypeServiceFacade productTypeServiceFacade)
        {
            _productTypeServiceFacade = productTypeServiceFacade;
        }

        public ActionResult Index()
        {
            var list = new List<ProductTypeDTO>
            {
                new ProductTypeDTO
                {
                    Point = 2,
                    Type = "Heavy"
                },
                new ProductTypeDTO
                {
                    Point=1,
                    Type="Regular"
                },
                new ProductTypeDTO
                {
                    Point=1,
                    Type="Specialized"
                }
            };
            foreach (var item in list)
            {
                _productTypeServiceFacade.Save(item);
            }
            return RedirectToAction("index","producttype");
    }
}
}