using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;

namespace WebDemo.Contorllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string token = "EAACEdEose0cBABTMrZBFnKwvwTZAZC3DhsdTeNYON0vQmLwfft5ki1bnZBinANa9gRXUbZAD8OXOF5hIfelxQMi6pwVvrOY4Dxrh1a5QzPgUrqfYSRHPHab8ZALb5y7zjBePVpqZABIzYMv7SN5ZBbyvIS8KDpxXyv3SPpujPooqoAZDZD";
            //var client = new FacebookClient()
            //{
            //    AccessToken = token,
            //    IsSecureConnection = true,
            //    Version = "2.1"
            //};
            //dynamic fbresult = client.Get("4");
            //FacebookUserModel facebookUser = Newtonsoft.Json.JsonConvert.DeserializeObject<FacebookUserModel>(fbresult.ToString());

            //var client = new FacebookClient();
            //client.AccessToken = token;

            //dynamic fbresult = client.Get("me?fields=id");


            return View();
        }
    }
}