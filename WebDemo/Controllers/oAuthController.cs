using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDemo.Controllers
{
    public class oAuthController : Controller
    {
        private string client_id = "";
        private string client_secret = "";
        private string redirect_uri = "";

        // GET: oAuth
        public ActionResult Index()
        {
            string Url = "https://www.facebook.com/dialog/oauth?scop={0}&redirect_url={1}&client_id={2}";

            string scop = "email,read_stream";
            string redirect_url_ecode = HttpUtility.UrlEncode(redirect_uri);

            return View();
        }
    }
}