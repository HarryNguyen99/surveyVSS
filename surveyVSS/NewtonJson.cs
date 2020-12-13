using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace surveyVSS
{

    public static class NewtonJson
    {
        private static readonly JsonSerializerSettings MicrosoftDateFormatSettings;
        static NewtonJson()
        {
            var settings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };
            MicrosoftDateFormatSettings = settings;
        }

        public static T Deserialize<T>(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString, MicrosoftDateFormatSettings);
            }
            catch (Exception e)
            {
                return default;
            }
        }

        public static T Deserialize<T>(string jsonString, JsonSerializerSettings setting)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString, setting);
            }
            catch
            {
                return default;
            }
        }

        public static T Deserialize<T>(string jsonString, string dateTimeFormat)
        {
            try
            {
                var converters = new JsonConverter[1];
                var converter = new IsoDateTimeConverter
                {
                    DateTimeFormat = dateTimeFormat
                };
                converters[0] = converter;
                return JsonConvert.DeserializeObject<T>(jsonString, converters);
            }
            catch
            {
                return default;
            }
        }

        public static object DeserializeObject(string jsonString, Type type)
        {
            try
            {
                return JsonConvert.DeserializeObject(jsonString, type);
            }
            catch
            {
                return default;
            }
        }

        public static string Serialize(object @object)
        {
            try
            {
                return JsonConvert.SerializeObject(@object, MicrosoftDateFormatSettings);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string Serialize(object @object, string dateTimeFormat)
        {
            try
            {
                var converters = new JsonConverter[1];
                var converter = new IsoDateTimeConverter
                {
                    DateTimeFormat = dateTimeFormat
                };
                converters[0] = converter;
                return JsonConvert.SerializeObject(@object, converters);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
