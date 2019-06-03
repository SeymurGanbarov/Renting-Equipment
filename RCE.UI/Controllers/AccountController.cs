using RCE.UI.Models;
using RCE.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCE.UI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserServiceFacade _userServiceFacade;

        public AccountController(UserServiceFacade userServiceFacade)
        {
            _userServiceFacade = userServiceFacade;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel model)
        {
            var result = _userServiceFacade.Login(model);
            if (result.IsSucceed)
            {
                Session["user"] = result.Data;
                return Json(new { IsSucceed = result.IsSucceed }, JsonRequestBehavior.AllowGet);
            }
            else return AjaxFailureResult(result);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction(nameof(Login));
        }
    }
}