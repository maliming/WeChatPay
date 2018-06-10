using Newtonsoft.Json;
using WeChatPay.Json;

namespace WeChatPay.Request
{
    public class RequestBase
    {
        /// <summary>
        /// 字段名: 应用ID
        /// 变量名: appid
        /// 必填: 是
        /// 类型: String(32)
        /// 描述: 微信开放平台审核通过的应用APPID
        /// </summary>
        [JsonProperty("appid")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string AppId { get; set; }

        /// <summary>
        /// 字段名: 商户号
        /// 变量名: mch_id
        /// 必填: 是
        /// 类型: String(32)
        /// 描述: 微信支付分配的商户号
        /// </summary>
        [JsonProperty("mch_id")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string MchId { get; set; }

        /// <summary>
        /// 字段名: 设备号
        /// 变量名: device_info
        /// 必填: 否
        /// 类型: String(32)
        /// 描述: 终端设备号(门店号或收银设备ID)，默认请传"WEB"
        /// </summary>
        [JsonProperty("device_info")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 字段名: 随机字符串
        /// 变量名: nonce_str
        /// 必填: 是
        /// 类型: String(32)
        /// 描述: 随机字符串，不长于32位。推荐随机数生成算法
        /// </summary>
        [JsonProperty("nonce_str")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string NonceStr { get; set; }

        /// <summary>
        /// 字段名: 签名类型
        /// 变量名: sign_type
        /// 必填: 否
        /// 类型: String(32)
        /// 描述: 签名类型，目前支持HMAC-SHA256和MD5，默认为MD5
        /// </summary>
        [JsonProperty("sign_type")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string SignType { get; set; }

        /// <summary>
        /// 字段名: 签名
        /// 变量名: sign
        /// 必填: 是
        /// 类型: String(32)
        /// C380BEC2BFD727A4B6845133519F3AD6
        /// 描述: 签名，详见签名生成算法
        /// </summary>
        [JsonProperty("sign")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string Sign { get; set; }
    }
}