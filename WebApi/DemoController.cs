using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Model;

namespace WebApi
{
    [RoutePrefix("api")]
    public class DemoController : ApiController
    {
        [HttpGet]
        public List<Demo> Get()
        {
            List<Demo> retVal = new List<Demo>() { 
                new Demo() { Id = 1, Name = "Andy" },
                new Demo() { Id = 2, Name = "Nick" },
                new Demo() { Id = 3, Name = "Allen" },
            };

            return retVal;
        }
    }
}
