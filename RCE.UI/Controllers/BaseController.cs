using RCE.Commons;
using RCE.UI.Helpers;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace RCE.UI.Controllers
{
    [Log]
    [Localization(LanguageHelper.DefaultLanguage)]
    public class BaseController : Controller
    {
        protected ActionResult AjaxFailureResult(LogicResult response, Action action = null)
        {
            action?.Invoke();
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            Response.StatusDescription = response.FailureResult.FirstOrDefault();
            return Json(response.FailureResult, JsonRequestBehavior.AllowGet);
        }
    }
}