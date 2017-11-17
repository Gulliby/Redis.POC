using System.IO;
using Newtonsoft.Json;

namespace Infrastructure.Common.Helpers
{
    public class CustomJsonSerializer
    {
        private readonly JsonSerializer _serializer;

        public CustomJsonSerializer(JsonSerializer serializer)
        {
            _serializer = serializer;
        }

        public static CustomJsonSerializer Default => new CustomJsonSerializer(new JsonSerializer
        {
            NullValueHandling = NullValueHandling.Ignore
        });

        public string Serialize<T>(T obj)
        {
            if (obj == null)
            {
                return null;
            }

            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    _serializer.Serialize(jsonTextWriter, obj);

                    return stringWriter.ToString();
                }
            }
        }

        public T Deserialize<T>(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return default(T);
            }    

            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return _serializer.Deserialize<T>(jsonTextReader);
                }
            }
        }
    }
}
