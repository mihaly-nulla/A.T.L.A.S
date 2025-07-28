using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Heart.IdentityModule.systems
{
    public class IdentitySystem
    {

        public string NpcName { get; set; }

        public string RaceID { get; set; }

        public string EnvironmentID { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string BiographySummary { get; set; }

        public string BiographyFull { get; set; }

        public string Role { get; set; }

        public string PhysicalDescription { get; set; }

        public List<string> CoreBeliefs { get; set; }

        public List<string> Likes { get; set; }

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
