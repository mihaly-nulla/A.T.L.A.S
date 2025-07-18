using A.T.L.A.S.Heart.PersonalityModule.systems;
using A.T.L.A.S.Heart.AffectionModule.systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using A.T.L.A.S.Heart.IdentityModule.systems;

namespace A.T.L.A.S.Factory.NPCs.CreationModule.DTOs
{
    public class CharacterRepresentation
    {
        [JsonPropertyName("npc_id")]
        public string NPCId { get; set; }

        [JsonPropertyName("npc_identity")]
        public IdentitySystem NPCIdentity { get; set; }

        [JsonPropertyName("npc_knowledge_summaries")]
        public List<string> NPCKnowledgeSummaries { get; set; }

        [JsonPropertyName("npc_personality")]
        public PersonalitySystem NPCPersonality { get; set; }

        [JsonPropertyName("npc_affections")]
        public AffectionSystem NPCAffection { get; set; }

    }
}