using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Heart.IdentityModule.systems
{
    public class IdentitySystem
    {

        [JsonPropertyName("name")]
        public string NpcName { get; set; }

        [JsonPropertyName("race_id")]
        public string RaceID { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("biography_summary")]
        public string BiographySummary { get; set; }

        [JsonPropertyName("biography_full")]
        public string BiographyFull { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("physical_description")]
        public string PhysicalDescription { get; set; }

        [JsonPropertyName("core_beliefs")]
        public List<string> CoreBeliefs { get; set; }

        public IdentitySystem()
        {
            this.NpcName = string.Empty;
            this.RaceID = string.Empty;
            this.Gender = string.Empty;
            this.BiographySummary = string.Empty;
            this.BiographyFull = string.Empty;
            this.Role = string.Empty;
            this.PhysicalDescription = string.Empty;
            this.CoreBeliefs = new List<string>();
        }

        public IdentitySystem(string npcName, 
                              string raceID,
                              bool gender,
                              int age,
                              string biographySummary,
                              string biographyFull,
                              string role,
                              string physicalDescription,
                              List<string> coreBeliefs)
        {
            this.NpcName = npcName;
            this.RaceID = raceID;
            this.Gender = gender ? "Male" : "Female";
            this.Age = age;
            this.BiographySummary = biographySummary;
            this.BiographyFull = biographyFull; 
            this.Role = role;
            this.PhysicalDescription = physicalDescription; 
            this.CoreBeliefs = coreBeliefs ?? new List<string>();
        }
    }
}
