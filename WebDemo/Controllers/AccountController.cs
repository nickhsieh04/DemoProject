using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;

namespace WebDemo.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult FacebookLogin(FacebookLoginModel model)
        {
            Session["uid"] = model.uid;
            Session["accessTolen"] = model.accessToken;

            return Json(new { success = true });
        }
    }
}