using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Newtonsoft.DTO.Personality
{
    public class NPCPersonality
    {
        [JsonProperty("OCEAN")]
        public NPCOcean ocean{ get; set; }

        [JsonProperty("SCHWARTZ")] 
        public NPCSchwartz schwartz { get; set; }

        [JsonProperty("dialogue_style")]
        public NPCDialogue dialogueStyle { get; set; }
    }
}
