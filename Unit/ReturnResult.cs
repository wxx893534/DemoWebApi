using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Unit
{
    public class ReturnResult
    {
        /// <summary>
        /// Gets or sets 当存在数据返回时，数据存储位置
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public object Data { get; set; } = null;

        /// <summary>
        /// 额外信息
        /// </summary>
        [JsonIgnore]
        public string Extmsg = string.Empty;

        private string msg = string.Empty;

        /// <summary>
        /// Gets or sets 返回的消息（成功或失败的通知信息）
        /// </summary>
        public string Message
        {
            get
            {
                if (!string.IsNullOrEmpty(Extmsg))
                {
                    return Extmsg;
                }
                return msg;
            }
            set
            {
                msg = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets 接口调用是否成功
        /// </summary>
        public bool Success { get; set; } = default(bool);

        /// <summary>
        /// Gets or sets 接口调用后返回的类型（用于确定接口中发生事件的具体类型，定位错误）
        /// </summary>
        public ERRORCODE Code { get; set; } = default(int);

        /// <summary>
        /// 填充模型
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="success">是否成功</param>
        /// <param name="code">事件类型</param>
        public ReturnResult FillModel(string message = "", bool success = false, ERRORCODE code = ERRORCODE.Access, object data = null)
        {
            this.Message = message;
            this.Success = success;
            this.Code = code;
            this.Data = data;
            return this;
        }

        public static implicit operator HttpResponseMessage(ReturnResult data)
        {
            return data.ToJsonResult();
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <returns></returns>
        public ReturnResult Fatal() => this.FillModel("程序异常，请联系管理员或稍后再试", false, ERRORCODE.Exception);
    }

    /// <summary>
    /// <see cref="ReturnResult.Code"/>错误代码枚举
    /// </summary>
    public enum ERRORCODE
    {
        /// <summary>
        /// 正常
        /// </summary>
        Access = 0,
        /// <summary>
        /// 异常
        /// </summary>
        Exception = -1,
        /// <summary>
        /// 非法访问
        /// </summary>
        IllegalAccess = -2,
        /// <summary>
        /// 无权限访问
        /// </summary>
        NoAccess = -3,
        /// <summary>
        /// 数据错误
        /// </summary>
        DataError = -4
    }

}
