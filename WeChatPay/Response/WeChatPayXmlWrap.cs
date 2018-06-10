using Newtonsoft.Json;

namespace WeChatPay.Response
{
    public class WeChatPayXmlWrap<T>
        where T : class, new()
    {
        public WeChatPayXmlWrap(T xml)
        {
            Xml = xml;
        }

        [JsonProperty("xml")]
        public T Xml { get; set; }
    }
}