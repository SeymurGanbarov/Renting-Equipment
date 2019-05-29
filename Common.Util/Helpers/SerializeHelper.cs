using Newtonsoft.Json;

namespace Common.Util
{
    public static class SerializerHelper
    {
        public static string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o);
        }
        public static string Serialize(object o, Formatting format)
        {
            return JsonConvert.SerializeObject(o, format);
        }
        public static string Serialize(object o, string dateFormatString, Formatting format = Formatting.None)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                DateFormatString = dateFormatString,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = format
            };
            return JsonConvert.SerializeObject(o, jsonSettings);
        }

        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
