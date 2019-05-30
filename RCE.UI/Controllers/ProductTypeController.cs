using RCE.UI.Services;
using System.Web.Mvc;

namespace RCE.UI.Controllers
{
    public class ProductTypeController : BaseController
    {
        private readonly ProductTypeServiceFacade _productTypeServiceFacade;

        public ProductTypeController(ProductTypeServiceFacade productTypeServiceFacade)
        {
            _productTypeServiceFacade = productTypeServiceFacade;
        }
       
        public ActionResult Index()
        {
            return View();
        }
    }
}