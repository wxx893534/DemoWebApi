using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unit;

namespace DemoWebApi.Controllers
{
    public class BaseController : ApiController
    {
        protected ReturnResult DataResult = new ReturnResult();
    }
}
