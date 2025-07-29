using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Newtonsoft.DTO.World._Location
{
    public class LocationDTO
    {
        [JsonProperty("location_id")]
        public string LocationID { get; set; }

        [JsonProperty("name")]
        public string LocationName { get; set; }
        [JsonProperty("type")]
        public string LocationType { get; set; }

        [JsonProperty("general_description")]
        public string LocationDescription { get; set; }

        [JsonProperty("key_features")]
        public List<string> LocationKeyFeatures { get; set; }
    }
}
