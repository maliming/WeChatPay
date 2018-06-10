using System.Collections.Generic;
using Newtonsoft.Json;
using WeChatPay.Json;
using WeChatPay.Response;

namespace WeChatPay.Request
{
    public class NotifyRequest : ResponseBase
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

        //--------------------------------------------------------------------------------------------


        /// <summary>
        /// 字段名: 用户标识
        /// 变量名: 	openid
        /// 必填: 是
        /// 类型: String(128)
        /// 描述: 用户在商户appid下的唯一标识
        /// </summary>
        [JsonProperty("openid")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string OpenId { get; set; }

        /// <summary>
        /// 字段名: 是否关注公众账号
        /// 变量名: is_subscribe
        /// 必填: 否
        /// 类型: String(1)
        /// 描述: 用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效
        /// </summary>
        [JsonProperty("is_subscribe")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string IsSubscribe { get; set; }

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
        /// 字段名: 付款银行
        /// 变量名: bank_type
        /// 必填: 是
        /// 类型: String(16)
        /// 描述: 银行类型，采用字符串类型的银行标识，银行类型见银行列表
        /// </summary>
        [JsonProperty("bank_type")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string BankType { get; set; }

        /// <summary>
        /// 字段名: 总金额
        /// 变量名: total_fee
        /// 必填: 是
        /// 类型: Int
        /// 描述: 订单总金额，单位为分
        /// </summary>
        [JsonProperty("total_fee")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public int TotalFee { get; set; }

        /// <summary>
        /// 字段名: 货币种类
        /// 变量名: fee_type
        /// 必填: 否
        /// 类型: String(8)
        /// 描述: 货币类型，符合ISO4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [JsonProperty("fee_type")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string FeeType { get; set; }

        /// <summary>
        /// 字段名: 现金支付金额
        /// 变量名: cash_fee
        /// 必填: 是
        /// 类型: Int
        /// 描述: 现金支付金额订单现金支付金额，详见支付金额
        /// </summary>
        [JsonProperty("cash_fee")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public int CashFee { get; set; }

        /// <summary>
        /// 字段名: 现金支付货币类型
        /// 变量名: cash_fee_type
        /// 必填: 否
        /// 类型: String(16)
        /// 描述: 货币类型，符合ISO4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [JsonProperty("cash_fee_type")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string CashFeeType { get; set; }

        /// <summary>
        /// 字段名: 代金券金额
        /// 变量名: coupon_fee
        /// 必填: 否
        /// 类型: Int
        /// 描述: 代金券或立减优惠金额<=订单总金额，订单总金额-代金券或立减优惠金额=现金支付金额，详见支付金额
        /// </summary>
        [JsonProperty("coupon_fee")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public int CouponFee { get; set; }

        /// <summary>
        /// 字段名: 代金券使用数量
        /// 变量名: coupon_count
        /// 必填: 否
        /// 类型: Int
        /// 描述: 代金券或立减优惠使用数量
        /// </summary>
        [JsonProperty("coupon_count")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public int CouponCount { get; set; }

        /// <summary>
        /// 字段名: 代金券ID
        /// 变量名: coupon_id_$n
        /// 必填: 否
        /// 类型: String(20)
        /// 描述: 代金券或立减优惠ID,$n为下标，从0开始编号
        /// </summary>
        public List<string> CouponIdCollect { get; set; }

        /// <summary>
        /// 字段名: 单个代金券支付金额
        /// 变量名: coupon_fee_$n
        /// 必填: 否
        /// 类型: Int
        /// 描述: 单个代金券或立减优惠支付金额,$n为下标，从0开始编号
        /// </summary>
        public List<int> CouponFeeCollect { get; set; }

        /// <summary>
        /// 字段名: 微信支付订单号
        /// 变量名: transaction_id
        /// 必填: 是
        /// 类型: String(32)
        /// 描述: 微信支付订单号
        /// </summary>
        [JsonProperty("transaction_id")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string TransactionId { get; set; }

        /// <summary>
        /// 字段名: 商户订单号
        /// 变量名: out_trade_no
        /// 必填: 是
        /// 类型: String(128)
        /// 描述: 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。
        /// </summary>
        [JsonProperty("out_trade_no")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 字段名: 	商家数据包
        /// 变量名: attach
        /// 必填: 否
        /// 类型: String(128)
        /// 描述: 	商家数据包，原样返回
        /// </summary>
        [JsonProperty("attach")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string Attach { get; set; }

        /// <summary>
        /// 字段名: 支付完成时间
        /// 变量名: time_end
        /// 必填: 是
        /// 类型: String(14)
        /// 描述: 	支付完成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。其他详见时间规则
        /// </summary>
        [JsonProperty("time_end")]
        [JsonConverter(typeof(CDataSectionConverter))]
        public string TimeEnd { get; set; }
    }
}