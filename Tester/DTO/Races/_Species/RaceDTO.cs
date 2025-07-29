using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.DTO.Races._Description;
using Newtonsoft.Json;

namespace Newtonsoft.DTO.Races._Species
{
    public class RaceDTO
    {
        [JsonProperty("race_id")]
        public string RaceID { get; set; }

        [JsonProperty("race_name")]
        public string RaceName { get; set; }

        [JsonProperty("race_description")]
        public RaceDescriptionDTO RaceDescription { get; set; }

        [JsonProperty("race_appearence_description")]
        public string RaceAppearenceDescription { get; set; }

        [JsonProperty("race_lore")] 
        public string RaceLore { get; set; }
    }
}
