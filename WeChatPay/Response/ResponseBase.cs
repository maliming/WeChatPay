using Newtonsoft.Json;
using WeChatPay.Json;

namespace WeChatPay.Response
{
    public class ResponseBase
    {
        /// <summary>
        /// 字段名: 返回状态码
        /// 变量名: return_code
        /// 必填: 是
        /// 类型: String(16)
        /// 描述: SUCCESS/FAIL 此字段是通信标识，非交易标识，交易是否成功需要查看result_code来判断
        /// </summary>
        [JsonProperty("return_code")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string ReturnCode { get; set; }

        /// <summary>
        /// 字段名: 返回信息
        /// 变量名: return_msg
        /// 必填: 否
        /// 类型: String(128)
        /// 描述: 返回信息，如非空，为错误原因签名失败参数格式校验错误
        /// </summary>
        [JsonProperty("return_msg")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string ReturnMsg { get; set; }

        [JsonIgnore]
        public bool Succeeded => ReturnCode == "SUCCESS";


        public static ResponseBase Error(string msg)
        {
            return new ResponseBase
            {
                ReturnCode = "FAIL",
                ReturnMsg = msg
            };
        }
    }
}