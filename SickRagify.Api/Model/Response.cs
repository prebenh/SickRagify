using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SickRagify.Model
{
    public class Response
    {
        public string Message { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ResponseResult Result { get; set; }
    }
}