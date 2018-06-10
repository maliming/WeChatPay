using Newtonsoft.Json;
using WeChatPay.Json;

namespace WeChatPay.Request
{
    /// <summary>
    /// 统一下单
    /// </summary>
    public class UnifiedOrderRequest : RequestBase
    {
        /// <summary>
        /// 字段名: 商品描述
        /// 变量名: body
        /// 必填: 是
        /// 类型: String(128)
        /// 描述: 商品描述交易字段格式根据不同的应用场景按照以下格式：
        /// APP——需传入应用市场上的APP名字-实际商品名称，天天爱消除-游戏充值。
        /// </summary>
        [JsonProperty("body")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string Body { get; set; }

        /// <summary>
        /// 字段名: 商品详情
        /// 变量名: detail
        /// 必填: 否
        /// 类型: String(8192)
        /// 描述: 商品详细描述，对于使用单品优惠的商户，改字段必须按照规范上传，详见“单品优惠参数说明”
        /// </summary>
        [JsonProperty("detail")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string Detail { get; set; }

        /// <summary>
        /// 字段名: 附加数据
        /// 变量名: attach
        /// 必填: 否
        /// 类型: String(127)
        /// 描述: 深圳分店	附加数据，在查询API和支付通知中原样返回，该字段主要用于商户携带订单的自定义数据
        /// </summary>
        [JsonProperty("attach")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string Attach { get; set; }

        /// <summary>
        /// 字段名: 商户订单号
        /// 变量名: out_trade_no
        /// 必填: 是
        /// 类型: String(32)
        /// 描述:  商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*且在同一个商户号下唯一。详见商户订单号
        /// </summary>
        [JsonProperty("out_trade_no")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 字段名: 货币类型
        /// 变量名: fee_type
        /// 必填: 否
        /// 类型: String(16)
        /// 描述: 符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [JsonProperty("fee_type")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string FeeType { get; set; }

        /// <summary>
        /// 字段名: 总金额
        /// 变量名: total_fee
        /// 必填: 是
        /// 类型: Int
        /// 描述: 订单总金额，单位为分，详见支付金额
        /// </summary>
        [JsonProperty("total_fee")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public int TotalFee { get; set; }

        /// <summary>
        /// 字段名: 终端IP
        /// 变量名: spbill_create_ip
        /// 必填: 是
        /// 类型: String(16)
        /// 描述: 用户端实际ip
        /// </summary>
        [JsonProperty("spbill_create_ip")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string SpbillCreateIp { get; set; }

        /// <summary>
        /// 字段名: 交易起始时间
        /// 变量名: time_start
        /// 必填: 否
        /// 类型: String(14)
        /// 描述: 订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。其他详见时间规则
        /// </summary>
        [JsonProperty("time_start")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string TimeStart { get; set; }

        /// <summary>
        /// 字段名: 交易结束时间
        /// 变量名: time_expire
        /// 必填: 否
        /// 类型: String(14)
        /// 描述:
        /// 订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010。订单失效时间是针对订单号而言的，由于在请求支付的时候有一个必传参数prepay_id只有两小时的有效期，所以在重入时间超过2小时的时候需要重新请求下单接口获取新的prepay_id。其他详见时间规则
        /// 建议：最短失效时间间隔大于1分钟
        /// </summary>
        [JsonProperty("time_expire")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string TimeExpire { get; set; }

        /// <summary>
        /// 字段名: 订单优惠标记
        /// 变量名: goods_tag
        /// 必填: 否
        /// 类型: String(32)
        /// 描述: 订单优惠标记，代金券或立减优惠功能的参数，说明详见代金券或立减优惠
        /// </summary>
        [JsonProperty("goods_tag")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string GoodsTag { get; set; }

        /// <summary>
        /// 字段名: 通知地址
        /// 变量名: notify_url
        /// 必填: 是
        /// 类型: String(256)
        /// 描述: 接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数。
        /// </summary>
        [JsonProperty("notify_url")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 字段名: 交易类型
        /// 变量名: trade_type
        /// 必填: 是
        /// 类型: String(16)
        /// 描述: 支付类型
        /// </summary>
        [JsonProperty("trade_type")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string TradeType { get; set; }

        /// <summary>
        /// 字段名: 指定支付方式
        /// 变量名: limit_pay
        /// 必填: 否
        /// 类型: String(32)
        /// 描述: no_credit--指定不能使用信用卡支付
        /// </summary>
        [JsonProperty("limit_pay")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string LimitPay { get; set; }

        /// <summary>
        /// 字段名: 场景信息
        /// 变量名: scene_info
        /// 必填: 否
        /// 类型: String(256)
        /// 描述:
        /// {
        /// "store_id": "SZT10000",
        /// "store_name":"腾讯大厦腾大餐厅"
        /// }
        /// 该字段用于统一下单时上报场景信息，目前支持上报实际门店信息。
        /// {
        /// "store_id": "", //门店唯一标识，选填，String(32)
        /// "store_name":"”//门店名称，选填，String(64)
        /// }
        /// </summary>
        [JsonProperty("scene_info")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string SceneInfo { get; set; }
    }
}