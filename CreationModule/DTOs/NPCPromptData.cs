using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.CreationModule.DTOs
{
    public class NPCPromptData
    {
        [JsonPropertyName("npc_id")]
        public string NPCId { get; set; }

        [JsonPropertyName("npc_name")]
        public string NPCName { get; set; }

        [JsonPropertyName("npc_knowledge")]
        public List<string> KnowledgeBaseContent { get; set; }
    }
}