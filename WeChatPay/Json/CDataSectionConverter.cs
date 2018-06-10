using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeChatPay.Json
{
    public class CDataSectionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var obj = serializer.Deserialize(reader, typeof(object));
            if (obj is JObject cdata && cdata.ContainsKey("#cdata-section"))
            {
                return cdata.GetValue("#cdata-section").ToObject(objectType);
            }

            return Convert.ChangeType(obj, objectType);
        }
    }
}