using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.DTO.NPC.Affection
{
    public class NPCAffection
    {
        [JsonProperty("relationships")]
        public List<NPCRelationship> Relationships { get; set; }

        [JsonProperty("social_standing")]
        public NPCSocialStanding SocialPerception { get; set; }
    }
}
