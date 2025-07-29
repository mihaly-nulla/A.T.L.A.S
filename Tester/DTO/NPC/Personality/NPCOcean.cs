using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.DTO.NPC.Personality
{
    public class NPCOcean
    {
        [JsonProperty("openness")]
        public int Openness { get; set; }

        [JsonProperty("conscientiousness")] 
        public int Conscientiousness { get; set; }

        [JsonProperty("extraversion")]
        public int Extraversion { get; set; }

        [JsonProperty("agreeableness")]
        public int Agreeableness { get; set; }

        [JsonProperty("neuroticism")]
        public int Neuroticism { get; set; }
    }
}
