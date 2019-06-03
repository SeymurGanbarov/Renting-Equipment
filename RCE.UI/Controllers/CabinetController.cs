using RCE.UI.Models;
using RCE.UI.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RCE.UI.Controllers
{
    public class CabinetController : Controller
    {
        private readonly CabinetServiceFacade _cabinetServiceFacade;
        public CabinetController(CabinetServiceFacade cabinetServiceFacade)
        {
            _cabinetServiceFacade = cabinetServiceFacade;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var result = _cabinetServiceFacade.GetProductsByUser(CurrentUser.Id);
            if (result.IsSucceed)
                return View(result.Data);
            else
                return View(new List<ProductCartModel>());
        }
    }
}