using Genesis.Factory.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Newtonsoft.Serializer
{
    public class NewtonsoftSerializer : ISerializer
    {
        public NewtonsoftSerializer()
        {
            // Constructor logic if needed
        }

        public T Deserialize<T>(string serializedObj)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.DeserializeObject<T>(serializedObj, settings);
        }

        public string Serialize<T>(T obj)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.SerializeObject(obj, settings);
        }

        public void SayHello()
        {
            Debug.WriteLine("Hello from NewtonsoftSerializer!");
        }
    }
}
