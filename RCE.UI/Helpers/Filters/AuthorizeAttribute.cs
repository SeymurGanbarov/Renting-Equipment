using System.Web;
using System.Web.Mvc;
using RCE.UI.Controllers;

namespace RCE.UI.Helpers
{
    public class AuthorizeAttribute : ActionFilterAttribute
    { 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(HttpContext.Current.Session["user"] == null)
            {
                string lang = (string)filterContext.RouteData.Values["lang"] ?? LanguageHelper.DefaultLanguage;
                filterContext.Result = new RedirectResult($"/{lang}/Account/Login");
                
            }
        }
    }
}