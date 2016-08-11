using Facebook;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebDemo.Common;
using WebDemo.Models;

namespace WebDemo.Contorllers
{
    public class HomeController : Controller
    {
        [CheckSessionTimeOut]
        public ActionResult Index()
        {
            var client = new FacebookClient()
            {
                AccessToken = Session["accessToken"].ToString(),
                Version = "v2.7"
            };
            dynamic fbresult = client.Get("me?fields=id,first_name,last_name,gender,locale,link,timezone,location,picture,age_range,name,email");
            FacebookUserModel facebookUser = Newtonsoft.Json.JsonConvert.DeserializeObject<FacebookUserModel>(fbresult.ToString());


            //dynamic friendListData = client.Get("/me/friends");

            return View(facebookUser);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            UrlHelper helpr = new UrlHelper();
            //string uuu = helpr.ToPublicUrl(RedirectUri);
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = System.Configuration.ConfigurationManager.AppSettings["FacebookAppId"],
                client_secret = System.Configuration.ConfigurationManager.AppSettings["FacebookSecret"],
                //redirect_uri = RedirectUri.AbsoluteUri,
                redirect_uri = toRedirectUri("FacebookCallback").AbsoluteUri,
                response_type = "code",
                scope = "email,user_friends", //Add other permissions as needed
                display = "popup"
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        private Uri toRedirectUri(string action)
        {
            var uriBuilder = new UriBuilder(Request.Url.AbsoluteUri);
            uriBuilder.Query = null;
            uriBuilder.Fragment = null;
            uriBuilder.Path = Url.Action(action);
            uriBuilder.Scheme = System.Configuration.ConfigurationManager.AppSettings["Protocol"] ?? "http";
            string port = System.Configuration.ConfigurationManager.AppSettings["Port"] ?? "80";
            try
            {
                uriBuilder.Port = Int32.Parse(port);
            }
            catch (Exception ex)
            {
                //this.Logging(WebSite.Enums.LogLevels.error, "從web config取得Port轉型失敗", ex.Message);
                uriBuilder.Port = 80;
            }
            return uriBuilder.Uri;
        }


        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        [AllowAnonymous]
        public ActionResult FacebookCallback(string code)
        {
            if (code == null)
                return RedirectToAction("Login", "Home");


            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = System.Configuration.ConfigurationManager.AppSettings["FacebookAppId"],
                client_secret = System.Configuration.ConfigurationManager.AppSettings["FacebookSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;

            // TODO: Authenticate User

            // Store the access token in the session
            Session["accessToken"] = accessToken;

            // update the facebook client with the access token so 
            // we can make requests on behalf of the user
            fb.AccessToken = accessToken;

            dynamic me = fb.Get("me?fields=first_name,last_name,id,email");
            string email = me.email;

            // Set the auth cookie
            FormsAuthentication.SetAuthCookie(email, false);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }

    public static class ExtensionMethod
    {
        public static string ToPublicUrl(this UrlHelper urlHelper, Uri relativeUri)
        {
            var httpContext = urlHelper.RequestContext.HttpContext;

            var uriBuilder = new UriBuilder
            {
                Host = httpContext.Request.Url.Host,
                Path = "/",
                Port = 80,
                Scheme = "http",
            };

            if (httpContext.Request.IsLocal)
            {
                uriBuilder.Port = httpContext.Request.Url.Port;
            }

            return new Uri(uriBuilder.Uri, relativeUri).AbsoluteUri;
        }
    }
}