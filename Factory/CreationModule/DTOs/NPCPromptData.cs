using A.T.L.A.S.Heart.PersonalityModule.systems;
using A.T.L.A.S.Heart.AffectionModule.systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Factory.CreationModule.DTOs
{
    public class NPCPromptData
    {
        [JsonPropertyName("npc_id")]
        public string NPCId { get; set; }

        [JsonPropertyName("npc_name")]
        public string NPCName { get; set; }

        [JsonPropertyName("npc_knowledge_summaries")]
        public List<string> NPCKnowledgeSummaries { get; set; }

        [JsonPropertyName("npc_personality")]
        public PersonalitySystem NPCPersonality { get; set; }

        [JsonPropertyName("npc_affections")]
        public AffectionSystem NPCAffection { get; set; }

    }
}