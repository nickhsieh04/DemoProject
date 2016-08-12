using Facebook;
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
            Session["accessToken"] = model.accessToken;

            return Json(new { success = true });
        }

        [HttpGet]
        public ActionResult UserDetails()
        {
            string token = Session["accessToken"].ToString();

            var client = new FacebookClient()
            {
                AccessToken = token
            };
            client.Version = "v2.7";
            dynamic fbresult = client.Get("me?fields=id,first_name,last_name,gender,locale,link,timezone,location,picture,name");
            FacebookUserModel facebookUser = Newtonsoft.Json.JsonConvert.DeserializeObject<FacebookUserModel>(fbresult.ToString());

            return View(facebookUser);
        }
    }
}