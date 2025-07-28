using Newtonsoft.DTO.Affection;
using Newtonsoft.DTO.Identity;
using Newtonsoft.DTO.Personality;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.DTO
{
    public class NPC
    {
        [JsonProperty("npc_id")]
        public string NPCId { get; set; }

        [JsonProperty("npc_identity")]
        public NPCIdentity NpcIdentity { get; set; }

        [JsonProperty("npc_personality")]
        public NPCPersonality NpcPersonality { get; set; }

        [JsonProperty("npc_affections")]
        public NPCAffection NpcAffections { get; set; }
    }
}
