using RCE.UI.Services;
using System.Linq;
using System.Web.Mvc;

namespace RCE.UI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ProductServiceFacade _productServiceFacade;
        public ProductController(ProductServiceFacade productServiceFacade)
        {
            _productServiceFacade = productServiceFacade;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View(_productServiceFacade.Data);
        }
    }
}