using Genesis.Heart.AffectionModule.systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genesis.Heart.IdentityModule.systems;
using Genesis.Heart.PersonalityModule.systems;

using Newtonsoft.Json;

namespace Genesis.Factory.NPCs.CreationModule.DTOs
{
    public class CharacterRepresentation
    {
        [JsonProperty("npc_id")]
        public string NPCId { get; set; }

        [JsonProperty("npc_identity")]
        public IdentitySystem NPCIdentity { get; set; }

        [JsonProperty("npc_knowledge_summaries")]
        public List<string> NPCKnowledgeSummaries { get; set; }

        [JsonProperty("npc_personality")]
        public PersonalitySystem NPCPersonality { get; set; }

        [JsonProperty("npc_affections")]
        public AffectionSystem NPCAffection { get; set; }

    }
}