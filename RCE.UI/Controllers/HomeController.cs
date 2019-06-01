using RCE.UI.Services;
using System.Web.Mvc;
using System.Linq;

namespace RCE.UI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction(nameof(ProductController.Index),"Product");
        }
    }
}