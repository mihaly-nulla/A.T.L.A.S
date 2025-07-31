using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Newtonsoft.DTO.Characters.Identity
{
    public class NPCIdentity
    {
        [JsonProperty("name")]
        public string NpcName { get; set; }

        [JsonProperty("race_id")]
        public string NpcRaceId { get; set; }

        [JsonProperty("origin_environment_id")]
        public string NpcOriginEnvironmentId { get; set; }

        [JsonProperty("gender")]
        public string NpcGender { get; set; }

        [JsonProperty("age")]
        public int NpcAge { get; set; }

        [JsonProperty("biography")]
        public string Biography{ get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("physical_description")]
        public string PhysicalDescription { get; set; }

        [JsonProperty("core_beliefs")]
        public List<string> CoreBeliefs { get; set; }

        [JsonProperty("likes")]
        public List<string> Likes { get; set; }

        [JsonProperty("dislikes")]
        public List<string> Dislikes { get; set; }
    }
}
