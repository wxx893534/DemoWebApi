using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Unit
{
    public static class WebApiJsonResult
    {
        /// <summary>
        /// 将字符串转为JSON返回
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static HttpResponseMessage ToJsonResult(this string result) => new HttpResponseMessage { Content = new StringContent(result, Encoding.GetEncoding("UTF-8"), "application/json") };

        /// <summary>
        /// 将对象转为JSON返回
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static HttpResponseMessage ToJsonResult(this object result) => new HttpResponseMessage { Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.GetEncoding("UTF-8"), "application/json") };

        /// <summary>
        /// 将字节流返回图片
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static HttpResponseMessage ToStreamResult(this byte[] result)
        {
            var resp = new HttpResponseMessage { Content = new ByteArrayContent(result) };
            resp.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpg");
            return resp;
        }
    }
}
