using Genesis.Factory.NPCs.CreationModule.DTOs;
using Genesis.Factory.Tools.SerializationInterface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tester
{
    public class TestSerializer : ISerializer
    {
        public TestSerializer()
        {
            // Constructor logic if needed
        }
        public T Deserialize<T>(string json)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.DeserializeObject<T>(json, settings);
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
    }
}
