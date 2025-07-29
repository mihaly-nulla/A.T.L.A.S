using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.DTO.NPC.Personality
{
    public class NPCSchwartz
    {
        [JsonProperty("self_direction")]
        public int SelfDirection { get; set; }

        [JsonProperty("stimulation")]
        public int Stimulation { get; set; }

        [JsonProperty("hedonism")]
        public int Hedonism { get; set; }

        [JsonProperty("achievement")]
        public int Achievement { get; set; }

        [JsonProperty("power")]
        public int Power { get; set; }

        [JsonProperty("security")]
        public int Security { get; set; }

        [JsonProperty("conformity")]
        public int Conformity { get; set; }

        [JsonProperty("tradition")]
        public int Tradition { get; set; }

        [JsonProperty("benevolence")]
        public int Benevolence { get; set; }

        [JsonProperty("universalism")]
        public int Universalism { get; set; }
    }
}
