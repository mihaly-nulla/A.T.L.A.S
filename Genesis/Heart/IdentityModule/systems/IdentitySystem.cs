using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace Genesis.Heart.IdentityModule.systems
{
    public class IdentitySystem
    {

        [JsonProperty("name")]
        public string NpcName { get; set; }

        [JsonProperty("race_id")]
        public string RaceID { get; set; }

        [JsonProperty("environment_id")]
        public string EnvironmentID { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("biography_summary")]
        public string BiographySummary { get; set; }

        [JsonProperty("biography_full")]
        public string BiographyFull { get; set; }

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
        public IdentitySystem()
        {
            NpcName = string.Empty;
            RaceID = string.Empty;
            EnvironmentID = string.Empty;
            Gender = string.Empty;
            BiographySummary = string.Empty;
            BiographyFull = string.Empty;
            Role = string.Empty;
            PhysicalDescription = string.Empty;
            CoreBeliefs = new List<string>();
        }

        public IdentitySystem(string npcName, 
                              string raceID,
                              string environmentID,
                              bool gender,
                              int age,
                              string biographySummary,
                              string biographyFull,
                              string role,
                              string physicalDescription,
                              List<string> coreBeliefs,
                              List<string> likes,
                              List<string> dislikes)
        {
            NpcName = npcName;
            RaceID = raceID;
            EnvironmentID = environmentID;
            Gender = gender ? "Male" : "Female";
            Age = age;
            BiographySummary = biographySummary;
            BiographyFull = biographyFull;
            Role = role;
            PhysicalDescription = physicalDescription;
            CoreBeliefs = coreBeliefs ?? new List<string>();
            Likes = likes ?? new List<string>();
            Dislikes = dislikes ?? new List<string>();
        }
    }
}
