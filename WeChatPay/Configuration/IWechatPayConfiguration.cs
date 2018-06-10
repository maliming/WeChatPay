namespace WeChatPay.Configuration
{
    public interface IWechatPayConfiguration
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        string MchId { get; set; }

        /// <summary>
        /// API密钥
        /// </summary>
        string ApiKey { get; set; }

        /// <summary>
        /// 证书Base64
        /// </summary>
        string SslCertBase64 { get; set; }

        /// <summary>
        /// 证书密码
        /// </summary>
        string SslCertPassword { get; set; }
    }
}