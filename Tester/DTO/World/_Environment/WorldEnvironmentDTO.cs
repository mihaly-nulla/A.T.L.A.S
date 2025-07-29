using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.DTO.World._Location;
using Newtonsoft.Json;

namespace Newtonsoft.DTO.World._Environment
{
    public class WorldEnvironmentDTO
    {
        [JsonProperty("environment_id")]
        public string EnvironmentID { get; set; }

        [JsonProperty("name")]
        public string EnvironmentName { get; set; }

        [JsonProperty("type")]
        public string EnvironmentType { get; set; }

        [JsonProperty("general_description")]
        public string EnvironmentDescription { get; set; }

        [JsonProperty("key_characteristics")]
        public List<string> EnvironmentCharacteristics { get; set; }

        [JsonProperty("historical_context_summary")]
        public string EnvironmentHistoricalContext { get; set; }

        [JsonProperty("major_locations_overview")]
        public Dictionary<string, LocationDTO> EnvironmentMajorLocations { get; set; }
    }
}
