using Newtonsoft.Json;

namespace WeChatPay.Response
{
    public class WakePaymentResponse
    {
        /// <summary>
        /// 字段名: 应用ID
        /// 变量名: appid
        /// 必填: 是
        /// 类型: String(32)
        /// 描述: 微信开放平台审核通过的应用APPID
        /// </summary>
        [JsonProperty("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 字段名: 商户号
        /// 变量名: partnerid
        /// 必填: 是
        /// 类型: String(32)
        /// 描述: 微信支付分配的商户号
        /// </summary>
        [JsonProperty("partnerid")]
        public string PartnerId { get; set; }

        /// <summary>
        /// 字段名: 预支付交易会话标识
        /// 变量名: prepay_id
        /// 必填: 是
        /// 类型: String(64)
        /// 描述: 微信生成的预支付回话标识，用于后续接口调用中使用，该值有效期为2小时
        /// </summary>
        [JsonProperty("prepayid")]
        public string PrepayId { get; set; }

        /// <summary>
        /// 字段名: 扩展字段
        /// 变量名: package
        /// 必填: 是
        /// 类型: String(128)
        /// 描述: 暂填写固定值Sign=WXPay
        /// </summary>
        [JsonProperty("package")]
        public string Package { get; set; }

        /// <summary>
        /// 字段名: 随机字符串
        /// 变量名: nonce_str
        /// 必填: 是
        /// 类型: String(32)
        /// 描述: 随机字符串，不长于32位。推荐随机数生成算法
        /// </summary>
        [JsonProperty("noncestr")]
        public string NonceStr { get; set; }

        /// <summary>
        /// 字段名: 时间戳
        /// 变量名: timestamp
        /// 必填: 是
        /// 类型: String(10)
        /// 描述: 时间戳，请见接口规则-参数规定
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// 字段名: 签名
        /// 变量名: sign
        /// 必填: 是
        /// 类型: String(32)
        /// C380BEC2BFD727A4B6845133519F3AD6
        /// 描述: 签名，详见签名生成算法
        /// </summary>
        [JsonProperty("sign")]
        public string Sign { get; set; }
    }
}
