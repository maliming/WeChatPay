namespace WeChatPay.Configuration
{
    public class WechatPayConfiguration : IWechatPayConfiguration
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// API密钥
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// 证书路径
        /// </summary>
        public string SslCertBase64 { get; set; }

        /// <summary>
        /// 证书密码
        /// </summary>
        public string SslCertPassword { get; set; }
    }
}