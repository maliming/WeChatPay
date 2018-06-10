using Newtonsoft.Json;
using WeChatPay.Json;

namespace WeChatPay.Response
{
    /// <summary>
    /// 统一下单
    /// </summary>
    public class UnifiedOrderResponse : ResponseBase
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
        /// 字段名: 签名
        /// 变量名: sign
        /// 必填: 是
        /// 类型: String(32)
        /// 描述: 签名，详见签名生成算法
        /// </summary>
        [JsonProperty("sign")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string Sign { get; set; }

        /// <summary>
        /// 字段名: 业务结果
        /// 变量名: result_code
        /// 必填: 是
        /// 类型: String(16)
        /// 描述: SUCCESS/FAIL
        /// </summary>
        [JsonProperty("result_code")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string ResultCode { get; set; }

        /// <summary>
        /// 字段名: 错误代码
        /// 变量名: err_code
        /// 必填: 否
        /// 类型: String(32)
        /// 描述: 详细参见第6节错误列表
        /// </summary>
        [JsonProperty("err_code")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string ErrCode { get; set; }

        /// <summary>
        /// 字段名: 错误代码描述
        /// 变量名: err_code_des
        /// 必填: 否
        /// 类型: String(128)
        /// 描述: 错误返回的信息描述
        /// </summary>
        [JsonProperty("err_code_des")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string ErrCodeDes { get; set; }

        /// <summary>
        /// 字段名: 交易类型
        /// 变量名: trade_type
        /// 必填: 是
        /// 类型: String(16)
        /// 描述: 调用接口提交的交易类型，取值如下：JSAPI，NATIVE，APP，详细说明见参数规定
        /// </summary>
        [JsonProperty("trade_type")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string TradeType { get; set; }

        /// <summary>
        /// 字段名: 预支付交易会话标识
        /// 变量名: prepay_id
        /// 必填: 是
        /// 类型: String(64)
        /// 描述: 微信生成的预支付回话标识，用于后续接口调用中使用，该值有效期为2小时
        /// </summary>
        [JsonProperty("prepay_id")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string PrepayId { get; set; }
    }
}