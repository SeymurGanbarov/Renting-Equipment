using System.Web.Mvc;

namespace RCE.UI.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return Content(Resources.UI.Hello);
        }
    }
}