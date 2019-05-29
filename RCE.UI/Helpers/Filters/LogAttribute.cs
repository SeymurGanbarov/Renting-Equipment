using Common.Util;
using NLog;
using System;
using System.Linq;
using System.Web.Mvc;

namespace RCE.UI.Helpers
{
    public class LogAttribute : ActionFilterAttribute
    {
        private static readonly ILogger _logger = _logger ?? LogManager.GetCurrentClassLogger();
        private DateTime _startTime;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _startTime = DateTime.Now;
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            try
            {
                if (filterContext.Controller.GetType().GetCustomAttributes(typeof(RequireHttpsAttribute), true).Length > 0)
                    return;
                var actionName = ((string)filterContext.RouteData.Values["action"]).ToUpper();
                if (!string.IsNullOrEmpty(actionName) && filterContext.Controller?.GetType().GetMethod(actionName)?
                        .GetCustomAttributes(typeof(DisableLogAttribute), true).Length > 0)
                {
                    return;
                }

                var routeData = filterContext.RouteData;
                var controller = routeData.Values["controller"].ToString().ToUpper();
                var requestUrl = filterContext.RequestContext.HttpContext.Request.Url?.ToString();
                var rq = filterContext.RequestContext.HttpContext.Request.QueryString;
                var rqDictionary = rq.AllKeys.ToDictionary(k => k, k => rq[k]);
                var requestQuery = SerializerHelper.Serialize(rqDictionary);
                var form = filterContext.RequestContext.HttpContext.Request.Form;
                var formDictionary = form.AllKeys.ToDictionary(k => k, k => form[k]);
                var requestForm = SerializerHelper.Serialize(formDictionary);
                var responseStatusCode = filterContext.HttpContext.Response.StatusCode;
                var requestExecutedTime = DateTime.Now - _startTime;
                _logger.Info(String.Concat(controller, " : ", actionName, " {0} {1} {2} {3} {4}"), new { responseStatusCode }, new { requestExecutedTime }, new { requestUrl }, new { requestQuery }, new { requestForm });
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception(string.Empty, ex);
#else
                  return;
#endif

            }
        }
    }
}