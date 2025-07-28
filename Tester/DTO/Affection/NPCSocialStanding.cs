using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.DTO.Affection
{
    public class NPCSocialStanding
    {
        [JsonProperty("reputation_score")]
        public int ReputationScore { get; set; }

        [JsonProperty("reputation_type")]
        public string ReputationType { get; set; }

        [JsonProperty("known_by_npcs")]
        public List<string> KnownByNPCs { get; set; }

        [JsonProperty("unfavorable_npcs")]
        public List<string> UnfavorableNPCs { get; set; }
    }
}
