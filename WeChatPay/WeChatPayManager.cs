using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using WeChatPay.Configuration;
using WeChatPay.HttpContent;
using WeChatPay.Request;
using WeChatPay.Response;

namespace WeChatPay
{
    /// <summary>
    /// 微信支付
    /// </summary>
    public class WeChatPayManager : IWeChatPayManager
    {
        private readonly IWechatPayConfiguration _wechatPayConfiguration;

        public WeChatPayManager(IWechatPayConfiguration wechatPayConfiguration)
        {
            _wechatPayConfiguration = wechatPayConfiguration;
        }

        /// <summary>
        /// 设置通用参数
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TRequest> SetCommonParameters<TRequest>(TRequest request)
            where TRequest : RequestBase
        {
            request.AppId = _wechatPayConfiguration.AppId;
            request.MchId = _wechatPayConfiguration.MchId;
            request.DeviceInfo = "APP";
            request.NonceStr = Get32Random();
            request.SignType = "HMAC-SHA256";

            request.Sign = await GetSignature(JsonConvert
                .DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(request)));

            return request;
        }

        /// <summary>
        /// 商户系统先调用该接口在微信支付服务后台生成预支付交易单，返回正确的预支付交易会话标识后再在APP里面调起支付。
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UnifiedOrderResponse> UnifiedOrder(UnifiedOrderRequest request)
        {
            using (var http = new HttpClient())
            {
                var responseMessage = await http.PostAsync("https://api.mch.weixin.qq.com/pay/unifiedorder",
                    new XmlContent<UnifiedOrderRequest>(request));

                var responseXmlString = await responseMessage.Content.ReadAsStringAsync();

                var response = ToResponse<UnifiedOrderResponse>(responseXmlString);

                return response;
            }
        }

        public async Task<WakePaymentResponse> WakePayment(WakePaymentRequest request)
        {
            var response = new WakePaymentResponse
            {
                AppId = _wechatPayConfiguration.AppId,
                PartnerId = _wechatPayConfiguration.MchId,
                NonceStr = Get32Random(),
                Package = "Sign=WXPay",
                PrepayId = request.PrepayId,
                Timestamp = GetTimestamp()
            };

            response.Sign = await GetSignature(
                JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(response)));

            return response;
        }

        /// <summary>
        /// 支付完成后，微信会把相关支付结果和用户信息发送给商户，商户需要接收处理，并返回应答。
        /// 对后台通知交互时，如果微信收到商户的应答不是成功或超时，微信认为通知失败，微信会通过一定的策略定期重新发起通知，尽可能提高通知的成功率，但微信不保证通知最终能成功。
        /// （通知频率为15/15/30/180/1800/1800/1800/1800/3600，单位：秒）
        /// 注意：同样的通知可能会多次发送给商户系统。商户系统必须能够正确处理重复的通知。
        /// 推荐的做法是，当收到通知进行处理时，首先检查对应业务数据的状态，判断该通知是否已经处理过，如果没有处理过再进行处理，如果处理过直接返回结果成功。在对业务数据进行状态检查和处理之前，要采用数据锁进行并发控制，以避免函数重入造成的数据混乱。
        /// 特别提醒：商户系统对于支付结果通知的内容一定要做签名验证,并校验返回的订单金额是否与商户侧的订单金额一致，防止数据泄漏导致出现“假通知”，造成资金损失。
        /// </summary>
        /// <param name="requestXml"></param>
        /// <returns></returns>
        public async Task<NotifyRequest> PaymentNotify(string requestXml)
        {
            var requestXmlDocument = new XmlDocument();
            requestXmlDocument.LoadXml(requestXml);

            var request = JsonConvert
                .DeserializeObject<WeChatPayXmlWrap<NotifyRequest>>(JsonConvert.SerializeXmlNode(requestXmlDocument))
                .Xml;

            if (request.CouponCount > 0)
            {
                request.CouponIdCollect = new List<string>();
                request.CouponFeeCollect = new List<int>();

                for (var i = 0; i < request.CouponCount; i++)
                {
                    request.CouponIdCollect.Add(requestXmlDocument.GetElementsByTagName($"coupon_id_{i}").Item(0)
                        .InnerText);
                    request.CouponFeeCollect.Add(Convert.ToInt32(requestXmlDocument
                        .GetElementsByTagName($"coupon_fee_{i}").Item(0)
                        .InnerText));
                }
            }

            return await Task.FromResult(request);
        }

        /// <summary>
        /// 对请求信息进行签名验证
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public async Task<bool> VerifySignature(string requestXml, string sign)
        {
            var requestXmlDocument = new XmlDocument();
            requestXmlDocument.LoadXml(requestXml);

            var request = new Dictionary<string, string>();
            foreach (XmlNode node in requestXmlDocument.GetElementsByTagName("xml")[0].ChildNodes)
            {
                if(node.Name.ToLower() != "sign") 
                {
                    request.Add(node.Name, node.InnerText);
                }
            }

            return await GetSignature(request) == sign;
        }

        /// <summary>
        /// 取32位随机数
        /// </summary>
        /// <returns></returns>
        private string Get32Random()
        {
            return string.Join("", Encoding.UTF8.GetBytes(Guid.NewGuid().ToString("N")).Select(Convert.ToInt32))
                .Substring(0, 32);
        }

        /// <summary>
        /// 标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数。注意：部分系统取到的值为毫秒级，需要转换成秒(10位数字)。
        /// </summary>
        /// <returns></returns>
        private string GetTimestamp()
        {
            return ((DateTime.UtcNow.AddHours(8).Ticks - new DateTime(1970, 1, 1).Ticks) / 10000000).ToString();
        }

        /// <summary>
        /// HmacSha256
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string HmacSha256(string data, string key)
        {
            var encData = Encoding.UTF8.GetBytes(data);

            var hmac = new HMac(new Sha256Digest());
            hmac.Init(new KeyParameter(Encoding.UTF8.GetBytes(key)));

            var output = new byte[hmac.GetMacSize()];
            hmac.BlockUpdate(encData, 0, encData.Length);
            hmac.DoFinal(output, 0);

            return BitConverter.ToString(output).Replace("-", string.Empty);
        }

        /// <summary>
        /// 对请求信息进行签名
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<string> GetSignature(Dictionary<string, string> request)
        {
            var sign = "";
            var signList = request
                .Where(x => !string.IsNullOrWhiteSpace(x.Value))
                .Where(x => x.Key.ToLower() != "sign")
                .OrderBy(x => x.Key)
                .ToList();

            signList.ForEach(x => sign += $"{x.Key}={x.Value}&");

            sign += $"key={_wechatPayConfiguration.ApiKey}";

            return await Task.FromResult(HmacSha256(sign, _wechatPayConfiguration.ApiKey));
        }

        private TResponse ToResponse<TResponse>(string xml)
            where TResponse : ResponseBase, new()
        {
            var responseXmlDocument = new XmlDocument();
            responseXmlDocument.LoadXml(xml);

            return JsonConvert
                .DeserializeObject<WeChatPayXmlWrap<TResponse>>(JsonConvert.SerializeXmlNode(responseXmlDocument))
                .Xml;
        }
    }
}