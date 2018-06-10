using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using WeChatPay.Request;
using WeChatPay.Response;

namespace WeChatPay.HttpContent
{
    public class XmlContent<TRequest>
        where TRequest : RequestBase, new()
    {
        public XmlContent(TRequest request)
        {
            Request = request;
        }

        private TRequest Request { get; }

        public static implicit operator StringContent(XmlContent<TRequest> _this)
        {
            var requestXml =
                JsonConvert.DeserializeXmlNode(JsonConvert.SerializeObject(new WeChatPayXmlWrap<TRequest>(_this.Request)));

            return new StringContent(requestXml.InnerXml, Encoding.UTF8, "application/xml");
        }
    }
}