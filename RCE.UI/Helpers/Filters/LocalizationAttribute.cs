using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCE.UI.Helpers
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        private readonly string _defaultLanguage;
        private string[] allowedLanguages = Enum.GetNames(typeof(LanguageEnum));

        public LocalizationAttribute(string defaultLanguage)
        {
            _defaultLanguage = defaultLanguage;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Take language from url if exist. Set default language if language not contain in url

            string lang = (string)filterContext.RouteData.Values["lang"] ?? _defaultLanguage;

            if(allowedLanguages.Any(m => m.ToLower() == lang.ToLower()))
               LanguageHelper.SetLanguage(lang);
        }
    }
}