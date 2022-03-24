using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebApi.Controllers
{
    public class DemoController : BaseController
    {
        /// <summary>
        /// 测试post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage demopost(ces pubces)
        {
            DataResult.Data= "{\"id\":" + pubces.id + ",\"name\":" + pubces.name + "}";
            DataResult.Message = "成功";
            DataResult.Success = true;
            return DataResult;
        }

        [HttpGet]
        public HttpResponseMessage demoget(int id,string name) 
        {
            DataResult.Data = "{\"id\":" + id + ",\"name\":" + name + "}";
            DataResult.Message = "成功";
            DataResult.Success = true;
            return DataResult;
        }

    }

    public class ces 
    {
        public int id { get; set; }

        public string name { get; set; }
    }
}
