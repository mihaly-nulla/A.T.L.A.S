using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.DTO.Affection
{
    public class NPCRelationship
    {
        [JsonProperty("target_npc_id")]
        public string TargetNpcId { get; set; }

        [JsonProperty("affection_score")]
        public int AffectionScore { get; set; }

        [JsonProperty("trust_score")]
        public int TrustScore { get; set; }

        [JsonProperty("friendship_level")]
        public string FriendshipLevel { get; set; }

        [JsonProperty("traits")]
        public List<string> Traits { get; set; }
    }
}
