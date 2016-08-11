using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            
        }

        protected void Application_EndRequest()
        {
            var loggedInUsers = (Dictionary<string, DateTime>)HttpRuntime.Cache["LoggedInUsers"];
            //if (User.Identity.IsAuthenticated)
            //{
            //    var userName = User.Identity.Name;
            //    if (loggedInUsers != null)
            //    {
            //        loggedInUsers[userName] = DateTime.Now;
            //        HttpRuntime.Cache["LoggedInUsers"] = loggedInUsers;
            //    }
            //}
            if (loggedInUsers != null)
            {
                foreach (var item in loggedInUsers.ToList())
                {
                    if (item.Value < DateTime.Now.AddMinutes(-5))
                    {
                        loggedInUsers.Remove(item.Key);
                    }
                }
                HttpRuntime.Cache["LoggedInUsers"] = loggedInUsers;
            }
        }
    }
}
