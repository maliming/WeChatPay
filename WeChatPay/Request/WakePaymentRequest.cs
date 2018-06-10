namespace WeChatPay.Request
{
    public class WakePaymentRequest
    {
        /// <summary>
        /// 字段名: 预支付交易会话标识
        /// 变量名: prepay_id
        /// 必填: 是
        /// 类型: String(64)
        /// 描述: 微信生成的预支付回话标识，用于后续接口调用中使用，该值有效期为2小时
        /// </summary>
        public string PrepayId { get; set; }
    }
}
