using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace WebDemo.Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CheckSessionTimeOutAttribute : ActionFilterAttribute
    {
        private static List<string> ExceptAction = new List<string> { "Login", "Facebook", "FacebookCallback" };

        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            var action = filterContext.RouteData.Values["action"].ToString();
            if (ExceptAction.Contains(action, StringComparer.OrdinalIgnoreCase))
                return;


            HttpSessionStateBase session = filterContext.HttpContext.Session;

            object user = null;
            if (session != null)
                user = session["UserAccount"];

            if (user == null || session == null || session.IsNewSession)
            {
                session.RemoveAll();
                session.Clear();
                session.Abandon();

                FormsAuthentication.SignOut();

                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Login" } });
            }

            //var context = filterContext.HttpContext;
            //if (context.Session != null)
            //{
            //    if (context.Session.IsNewSession)
            //    {
            //        string sessionCookie = context.Request.Headers["Cookie"];
            //        if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
            //        {
            //            FormsAuthentication.SignOut();
            //            string redirectTo = "~/Home/Login";
            //            if (!string.IsNullOrEmpty(context.Request.RawUrl))
            //            {
            //                redirectTo = string.Format("~/Home/Login?ReturnUrl={0}", HttpUtility.UrlEncode(context.Request.RawUrl));
            //            }
            //            filterContext.HttpContext.Response.Redirect(redirectTo, true);
            //        }
            //    }
            //}
            base.OnActionExecuting(filterContext);
        }
    }
}